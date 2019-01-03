using DataSerializer.Model;
using DataTransferGraph2.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataSerializer.SerializationMapper
{
    public class SerializationTypeMapper
    {
        public static XMLTypeMetadata MapToXMLModel(DTG2TypeMetadata typeMetadata)
        {
            XMLTypeMetadata dTG2TypeMetadata = new XMLTypeMetadata
            {
                TypeName = typeMetadata.TypeName,
                DeclaringType = EmitDeclaringType(typeMetadata.DeclaringType),
                Constructors = SerializationMethodMapper.EmitMethods(typeMetadata.Constructors).ToList(),
                Methods = SerializationMethodMapper.EmitMethods(typeMetadata.Methods).ToList(),
                NestedTypes = EmitNestedTypes(typeMetadata.NestedTypes).ToList(),
                ImplementedInterfaces = EmitImplements(typeMetadata.ImplementedInterfaces).ToList(),
                IsGenericType = typeMetadata.IsGenericType,
                BaseType = EmitExtends(typeMetadata.BaseType),
                Properties = SerializationPropertyMapper.EmitProperties(typeMetadata.Properties).ToList(),
            };

            if(dTG2TypeMetadata.IsGenericType)
            {
                dTG2TypeMetadata.GenericArguments = EmitGenericArguments(typeMetadata.GenericArguments).ToList();
            }

            return dTG2TypeMetadata;
        }

        public static XMLTypeMetadata fillType(XMLTypeMetadata dtg2TypeMetadata, DTG2TypeMetadata typeMetadata)
        {
            dtg2TypeMetadata.TypeName = typeMetadata.TypeName;
            dtg2TypeMetadata.DeclaringType = EmitDeclaringType(typeMetadata.DeclaringType);
            dtg2TypeMetadata.Constructors = SerializationMethodMapper.EmitMethods(typeMetadata.Constructors).ToList();
            dtg2TypeMetadata.Methods = SerializationMethodMapper.EmitMethods(typeMetadata.Methods).ToList();
            dtg2TypeMetadata.NestedTypes = EmitNestedTypes(typeMetadata.NestedTypes).ToList();
            dtg2TypeMetadata.ImplementedInterfaces = EmitImplements(typeMetadata.ImplementedInterfaces).ToList();
            dtg2TypeMetadata.IsGenericType = typeMetadata.IsGenericType;
            if (typeMetadata.IsGenericType)
                dtg2TypeMetadata.GenericArguments = EmitGenericArguments(typeMetadata.GenericArguments).ToList();
            dtg2TypeMetadata.BaseType = EmitExtends(typeMetadata.BaseType);
            dtg2TypeMetadata.Properties = SerializationPropertyMapper.EmitProperties(typeMetadata.Properties).ToList();

            return dtg2TypeMetadata;
        }

        internal static XMLTypeMetadata EmitReference(DTG2TypeMetadata type)
        {
            if (HelperDictonaries.TypeDictonary.ContainsKey(type))
            {
                return HelperDictonaries.TypeDictonary[type];
            }

            if (!type.IsGenericType)
            {
                HelperDictonaries.TypeDictonary[type] = MapToXMLModel(type);

                return HelperDictonaries.TypeDictonary[type];
            }
            else
                return MapToXMLModel(type);
        }
        internal static IEnumerable<XMLTypeMetadata> EmitGenericArguments(IEnumerable<DTG2TypeMetadata> arguments)
        {
            return from DTG2TypeMetadata _argument in arguments select EmitReference(_argument);
        }

        private static XMLTypeMetadata EmitDeclaringType(DTG2TypeMetadata declaringType)
        {
            return EmitReference(declaringType);
        }
        private static IEnumerable<XMLTypeMetadata> EmitNestedTypes(IEnumerable<DTG2TypeMetadata> nestedTypes)
        {
            return from _type in nestedTypes
                   select MapToXMLModel(_type);
        }
        private static IEnumerable<XMLTypeMetadata> EmitImplements(IEnumerable<DTG2TypeMetadata> interfaces)
        {
            return from currentInterface in interfaces
                   select EmitReference(currentInterface);
        }
        private static XMLTypeMetadata EmitExtends(DTG2TypeMetadata baseType)
        {
            return EmitReference(baseType);
        }
    }
}
