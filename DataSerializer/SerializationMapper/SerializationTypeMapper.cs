using DataSerializer.Model;
using DataTransferGraph2.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataSerializer.SerializationMapper
{
    public class SerializationTypeMapper
    {
        public static XMLTypeMetadata MapToXML(DTG2TypeMetadata typeMetadata)
        {
            XMLTypeMetadata xmlTypeMetadata = new XMLTypeMetadata
            {
                TypeName = typeMetadata.TypeName,
                DeclaringType = EmitDeclaringType(typeMetadata.DeclaringType),
                Constructors = SerializationMethodMapper.EmitMethods(typeMetadata.Constructors),
                Methods = SerializationMethodMapper.EmitMethods(typeMetadata.Methods),
                NestedTypes = EmitNestedTypes(typeMetadata.NestedTypes),
                ImplementedInterfaces = EmitImplements(typeMetadata.ImplementedInterfaces),
                GenericArguments = CheckGenericArguments(typeMetadata),
                BaseType = EmitExtends(typeMetadata.BaseType),
                Properties = SerializationPropertyMapper.EmitProperties(typeMetadata.Properties),
                IsGenericType = typeMetadata.IsGenericType
            };

            return xmlTypeMetadata;
        }

        public static XMLTypeMetadata fillType(XMLTypeMetadata dtg2TypeMetadata, DTG2TypeMetadata typeMetadata)
        {
            dtg2TypeMetadata.TypeName = typeMetadata.TypeName;
            dtg2TypeMetadata.DeclaringType = EmitDeclaringType(typeMetadata.DeclaringType);
            dtg2TypeMetadata.Constructors = SerializationMethodMapper.EmitMethods(typeMetadata.Constructors);
            dtg2TypeMetadata.Methods = SerializationMethodMapper.EmitMethods(typeMetadata.Methods);
            dtg2TypeMetadata.NestedTypes = EmitNestedTypes(typeMetadata.NestedTypes);
            dtg2TypeMetadata.ImplementedInterfaces = EmitImplements(typeMetadata.ImplementedInterfaces);
            if (typeMetadata.GenericArguments != null)
                dtg2TypeMetadata.GenericArguments = EmitGenericArguments(typeMetadata.GenericArguments);
            else dtg2TypeMetadata.GenericArguments = null;
            //dtg2TypeMetadata.Modifiers = EmitModifiers(typeMetadata);
            dtg2TypeMetadata.BaseType = EmitExtends(typeMetadata.BaseType);
            dtg2TypeMetadata.Properties = SerializationPropertyMapper.EmitProperties(typeMetadata.Properties);

            return dtg2TypeMetadata;
        }

        public static IEnumerable<XMLTypeMetadata> CheckGenericArguments(DTG2TypeMetadata typeMetadata)
        {
            if (typeMetadata.GenericArguments != null)
                return EmitGenericArguments(typeMetadata.GenericArguments);
            return null;
        }

        internal static XMLTypeMetadata EmitReference(DTG2TypeMetadata type)
        {
            if (HelperDictonaries.TypeDictonary.ContainsKey(type))
            {
                return HelperDictonaries.TypeDictonary[type];
            }


            if (!type.IsGenericType)
            {
                HelperDictonaries.TypeDictonary[type] = MapToXML(type);

                return HelperDictonaries.TypeDictonary[type];
            }
            else
                return MapToXML(type);
        }
        internal static IEnumerable<XMLTypeMetadata> EmitGenericArguments(IEnumerable<DTG2TypeMetadata> arguments)
        {
            return from DTG2TypeMetadata _argument in arguments select EmitReference(_argument);
        }

        private static XMLTypeMetadata EmitDeclaringType(DTG2TypeMetadata declaringType)
        {
            if (declaringType == null)
                return null;
            return EmitReference(declaringType);
        }
        private static IEnumerable<XMLTypeMetadata> EmitNestedTypes(IEnumerable<DTG2TypeMetadata> nestedTypes)
        {
            return from _type in nestedTypes
                   select MapToXML(_type);
        }
        private static IEnumerable<XMLTypeMetadata> EmitImplements(IEnumerable<DTG2TypeMetadata> interfaces)
        {
            return from currentInterface in interfaces
                   select EmitReference(currentInterface);
        }
        private static XMLTypeMetadata EmitExtends(DTG2TypeMetadata baseType)
        {
            if (baseType == null)
                return null;
            return EmitReference(baseType);
        }
    }
}
