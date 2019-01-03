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
                //Constructors = SerializationMethodMapper.EmitMethods(typeMetadata.Constructors),
                //Methods = SerializationMethodMapper.EmitMethods(typeMetadata.Methods),
                //NestedTypes = EmitNestedTypes(typeMetadata.NestedTypes),
                ImplementedInterfaces = EmitImplements(typeMetadata.ImplementedInterfaces),
                IsGenericType = typeMetadata.IsGenericType,
                BaseType = EmitExtends(typeMetadata.BaseType),
                Properties = SerializationPropertyMapper.EmitProperties(typeMetadata.Properties),
            };

            if(dTG2TypeMetadata.IsGenericType)
            {
                dTG2TypeMetadata.GenericArguments = EmitGenericArguments(typeMetadata.GenericArguments);
            }

            return dTG2TypeMetadata;
        }

        public static XMLTypeMetadata fillType(XMLTypeMetadata dtg2TypeMetadata, DTG2TypeMetadata typeMetadata)
        {
            dtg2TypeMetadata.TypeName = typeMetadata.TypeName;
            dtg2TypeMetadata.Constructors = SerializationMethodMapper.EmitMethods(typeMetadata.Constructors);
            dtg2TypeMetadata.Methods = SerializationMethodMapper.EmitMethods(typeMetadata.Methods);
            dtg2TypeMetadata.NestedTypes = EmitNestedTypes(typeMetadata.NestedTypes);
            dtg2TypeMetadata.ImplementedInterfaces = EmitImplements(typeMetadata.ImplementedInterfaces);
            dtg2TypeMetadata.IsGenericType = typeMetadata.IsGenericType;
            if (typeMetadata.IsGenericType)
                dtg2TypeMetadata.GenericArguments = EmitGenericArguments(typeMetadata.GenericArguments);
            dtg2TypeMetadata.BaseType = EmitExtends(typeMetadata.BaseType);
            dtg2TypeMetadata.Properties = SerializationPropertyMapper.EmitProperties(typeMetadata.Properties);

            return dtg2TypeMetadata;
        }

        internal static XMLTypeMetadata EmitReference(DTG2TypeMetadata type)
        {
            if(type == null)
                return null;
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
