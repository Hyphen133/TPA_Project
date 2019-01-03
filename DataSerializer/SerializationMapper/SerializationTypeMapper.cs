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
                //DeclaringType = EmitDeclaringTypeXML(typeMetadata.DeclaringType),
                //Constructors = SerializationMethodMapper.EmitMethodsXML(typeMetadata.Constructors),
                //Methods = SerializationMethodMapper.EmitMethodsXML(typeMetadata.Methods),
                //NestedTypes = EmitNestedTypesXML(typeMetadata.NestedTypes),
                //ImplementedInterfaces = EmitImplementsXML(typeMetadata.ImplementedInterfaces),
                //GenericArguments = CheckGenericArgumentsXML(typeMetadata),
                //BaseType = EmitExtendsXML(typeMetadata.BaseType),
                //Properties = SerializationPropertyMapper.EmitPropertiesXML(typeMetadata.Properties),
                //IsGenericType = typeMetadata.IsGenericType
            };

            return xmlTypeMetadata;
        }

        public static XMLTypeMetadata FillTypeXML(XMLTypeMetadata dtg2TypeMetadata, DTG2TypeMetadata typeMetadata)
        {
            dtg2TypeMetadata.TypeName = typeMetadata.TypeName;
            dtg2TypeMetadata.DeclaringType = EmitDeclaringTypeXML(typeMetadata.DeclaringType);
            dtg2TypeMetadata.Constructors = SerializationMethodMapper.EmitMethodsXML(typeMetadata.Constructors);
            dtg2TypeMetadata.Methods = SerializationMethodMapper.EmitMethodsXML(typeMetadata.Methods);
            dtg2TypeMetadata.NestedTypes = EmitNestedTypesXML(typeMetadata.NestedTypes);
            dtg2TypeMetadata.ImplementedInterfaces = EmitImplementsXML(typeMetadata.ImplementedInterfaces);
            if (typeMetadata.GenericArguments != null)
                dtg2TypeMetadata.GenericArguments = EmitGenericArgumentsXML(typeMetadata.GenericArguments);
            else dtg2TypeMetadata.GenericArguments = null;
            //dtg2TypeMetadata.Modifiers = EmitModifiers(typeMetadata);
            dtg2TypeMetadata.BaseType = EmitExtendsXML(typeMetadata.BaseType);
            dtg2TypeMetadata.Properties = SerializationPropertyMapper.EmitPropertiesXML(typeMetadata.Properties);

            return dtg2TypeMetadata;
        }

        public static IEnumerable<XMLTypeMetadata> CheckGenericArgumentsXML(DTG2TypeMetadata typeMetadata)
        {
            if (typeMetadata.GenericArguments != null)
                return EmitGenericArgumentsXML(typeMetadata.GenericArguments);
            return null;
        }

        internal static XMLTypeMetadata EmitReferenceXML(DTG2TypeMetadata type)
        {
            if (type == null) return null;
            if (HelperDictonaries.TypeDictonaryToXML.ContainsKey(type))
            {
                return HelperDictonaries.TypeDictonaryToXML[type];
            }


            if (!type.IsGenericType)
            {
                HelperDictonaries.TypeDictonaryToXML[type] = MapToXML(type);

                return HelperDictonaries.TypeDictonaryToXML[type];
            }
            else
                return MapToXML(type);
        }
        internal static IEnumerable<XMLTypeMetadata> EmitGenericArgumentsXML(IEnumerable<DTG2TypeMetadata> arguments)
        {
            if (arguments == null) return null;
            return from DTG2TypeMetadata _argument in arguments select EmitReferenceXML(_argument);
        }

        private static XMLTypeMetadata EmitDeclaringTypeXML(DTG2TypeMetadata declaringType)
        {
            if (declaringType == null)
                return null;
            return EmitReferenceXML(declaringType);
        }
        private static IEnumerable<XMLTypeMetadata> EmitNestedTypesXML(IEnumerable<DTG2TypeMetadata> nestedTypes)
        {
            return from _type in nestedTypes
                   select MapToXML(_type);
        }
        private static IEnumerable<XMLTypeMetadata> EmitImplementsXML(IEnumerable<DTG2TypeMetadata> interfaces)
        {
            return from currentInterface in interfaces
                   select EmitReferenceXML(currentInterface);
        }
        private static XMLTypeMetadata EmitExtendsXML(DTG2TypeMetadata baseType)
        {
            if (baseType == null)
                return null;
            return EmitReferenceXML(baseType);
        }





        
        public static DTG2TypeMetadata MapToDTG(XMLTypeMetadata typeMetadata)
        {
            DTG2TypeMetadata xmlTypeMetadata = new DTG2TypeMetadata
            {
                TypeName = typeMetadata.TypeName,
                DeclaringType = EmitDeclaringTypeDTG(typeMetadata.DeclaringType),
                Constructors = SerializationMethodMapper.EmitMethodsDTG(typeMetadata.Constructors),
                Methods = SerializationMethodMapper.EmitMethodsDTG(typeMetadata.Methods),
                NestedTypes = EmitNestedTypesDTG(typeMetadata.NestedTypes),
                ImplementedInterfaces = EmitImplementsDTG(typeMetadata.ImplementedInterfaces),
                GenericArguments = CheckGenericArgumentsDTG(typeMetadata),
                BaseType = EmitExtendsDTG(typeMetadata.BaseType),
                Properties = SerializationPropertyMapper.EmitPropertiesDTG(typeMetadata.Properties),
                IsGenericType = typeMetadata.IsGenericType
            };

            return xmlTypeMetadata;
        }

        public static DTG2TypeMetadata fillType(DTG2TypeMetadata dtg2TypeMetadata, XMLTypeMetadata typeMetadata)
        {
            dtg2TypeMetadata.TypeName = typeMetadata.TypeName;
            dtg2TypeMetadata.DeclaringType = EmitDeclaringTypeDTG(typeMetadata.DeclaringType);
            dtg2TypeMetadata.Constructors = SerializationMethodMapper.EmitMethodsDTG(typeMetadata.Constructors);
            dtg2TypeMetadata.Methods = SerializationMethodMapper.EmitMethodsDTG(typeMetadata.Methods);
            dtg2TypeMetadata.NestedTypes = EmitNestedTypesDTG(typeMetadata.NestedTypes);
            dtg2TypeMetadata.ImplementedInterfaces = EmitImplementsDTG(typeMetadata.ImplementedInterfaces);
            if (typeMetadata.GenericArguments != null)
                dtg2TypeMetadata.GenericArguments = EmitGenericArgumentsDTG(typeMetadata.GenericArguments);
            else dtg2TypeMetadata.GenericArguments = null;
            //dtg2TypeMetadata.Modifiers = EmitModifiers(typeMetadata);
            dtg2TypeMetadata.BaseType = EmitExtendsDTG(typeMetadata.BaseType);
            dtg2TypeMetadata.Properties = SerializationPropertyMapper.EmitPropertiesDTG(typeMetadata.Properties);

            return dtg2TypeMetadata;
        }

        public static IEnumerable<DTG2TypeMetadata> CheckGenericArgumentsDTG(XMLTypeMetadata typeMetadata)
        {
            if (typeMetadata.GenericArguments != null)
                return EmitGenericArgumentsDTG(typeMetadata.GenericArguments);
            return null;
        }

        internal static DTG2TypeMetadata EmitReferenceDTG(XMLTypeMetadata type)
        {
            if (HelperDictonaries.TypeDictonaryToDTG.ContainsKey(type))
            {
                return HelperDictonaries.TypeDictonaryToDTG[type];
            }


            if (!type.IsGenericType)
            {
                HelperDictonaries.TypeDictonaryToDTG[type] = MapToDTG(type);

                return HelperDictonaries.TypeDictonaryToDTG[type];
            }
            else
                return MapToDTG(type);
        }
        internal static IEnumerable<DTG2TypeMetadata> EmitGenericArgumentsDTG(IEnumerable<XMLTypeMetadata> arguments)
        {
            return from XMLTypeMetadata _argument in arguments select EmitReferenceDTG(_argument);
        }

        private static DTG2TypeMetadata EmitDeclaringTypeDTG(XMLTypeMetadata declaringType)
        {
            if (declaringType == null)
                return null;
            return EmitReferenceDTG(declaringType);
        }
        private static IEnumerable<DTG2TypeMetadata> EmitNestedTypesDTG(IEnumerable<XMLTypeMetadata> nestedTypes)
        {
            return from _type in nestedTypes
                   select MapToDTG(_type);
        }
        private static IEnumerable<DTG2TypeMetadata> EmitImplementsDTG(IEnumerable<XMLTypeMetadata> interfaces)
        {
            return from currentInterface in interfaces
                   select EmitReferenceDTG(currentInterface);
        }
        private static DTG2TypeMetadata EmitExtendsDTG(XMLTypeMetadata baseType)
        {
            if (baseType == null)
                return null;
            return EmitReferenceDTG(baseType);
        }
    }
}
