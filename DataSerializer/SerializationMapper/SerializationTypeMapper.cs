using DataSerializer.Model;
using DataTransferGraph.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataSerializer.SerializationMapper
{
    public class SerializationTypeMapper
    {
        public static XMLTypeMetadata MapToXML(DTGTypeMetadata typeMetadata)
        {
            XMLTypeMetadata xmlTypeMetadata = new XMLTypeMetadata
            {
                TypeName = typeMetadata.TypeName,
                DeclaringType = EmitDeclaringTypeXML(typeMetadata.DeclaringType),
                Constructors = SerializationMethodMapper.EmitMethodsXML(typeMetadata.Constructors),
                Methods = SerializationMethodMapper.EmitMethodsXML(typeMetadata.Methods),
                NestedTypes = EmitNestedTypesXML(typeMetadata.NestedTypes),
                ImplementedInterfaces = EmitImplementsXML(typeMetadata.ImplementedInterfaces),
                GenericArguments = CheckGenericArgumentsXML(typeMetadata),
                BaseType = EmitExtendsXML(typeMetadata.BaseType),
                Properties = SerializationPropertyMapper.EmitPropertiesXML(typeMetadata.Properties),
                IsGenericType = typeMetadata.IsGenericType
            };

            return xmlTypeMetadata;
        }

        public static XMLTypeMetadata FillTypeXML(XMLTypeMetadata dtg2TypeMetadata, DTGTypeMetadata typeMetadata)
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

        public static IEnumerable<XMLTypeMetadata> CheckGenericArgumentsXML(DTGTypeMetadata typeMetadata)
        {
            if (typeMetadata.GenericArguments != null)
                return EmitGenericArgumentsXML(typeMetadata.GenericArguments);
            return null;
        }

        internal static XMLTypeMetadata EmitReferenceXML(DTGTypeMetadata type)
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
        internal static IEnumerable<XMLTypeMetadata> EmitGenericArgumentsXML(IEnumerable<DTGTypeMetadata> arguments)
        {
            if (arguments == null) return null;
            return from DTGTypeMetadata _argument in arguments select EmitReferenceXML(_argument);
        }

        private static XMLTypeMetadata EmitDeclaringTypeXML(DTGTypeMetadata declaringType)
        {
            if (declaringType == null)
                return null;
            return EmitReferenceXML(declaringType);
        }
        private static IEnumerable<XMLTypeMetadata> EmitNestedTypesXML(IEnumerable<DTGTypeMetadata> nestedTypes)
        {
            return from _type in nestedTypes
                   select MapToXML(_type);
        }
        private static IEnumerable<XMLTypeMetadata> EmitImplementsXML(IEnumerable<DTGTypeMetadata> interfaces)
        {
            return from currentInterface in interfaces
                   select EmitReferenceXML(currentInterface);
        }
        private static XMLTypeMetadata EmitExtendsXML(DTGTypeMetadata baseType)
        {
            if (baseType == null)
                return null;
            return EmitReferenceXML(baseType);
        }





        
        public static DTGTypeMetadata MapToDTG(XMLTypeMetadata typeMetadata)
        {
            DTGTypeMetadata xmlTypeMetadata = new DTGTypeMetadata
            {
                TypeName = typeMetadata.TypeName,
                DeclaringType = EmitDeclaringTypeDTG(typeMetadata.DeclaringType),
                Constructors = SerializationMethodMapper.EmitMethodsDTG(typeMetadata.ConstructorsL),
                Methods = SerializationMethodMapper.EmitMethodsDTG(typeMetadata.MethodsL),
                NestedTypes = EmitNestedTypesDTG(typeMetadata.NestedTypesL),
                ImplementedInterfaces = EmitImplementsDTG(typeMetadata.ImplementedInterfacesL),
                GenericArguments = CheckGenericArgumentsDTG(typeMetadata),
                BaseType = EmitExtendsDTG(typeMetadata.BaseType),
                Properties = SerializationPropertyMapper.EmitPropertiesDTG(typeMetadata.PropertiesL),
                IsGenericType = typeMetadata.IsGenericType
            };

            return xmlTypeMetadata;
        }

        public static DTGTypeMetadata fillType(DTGTypeMetadata dtg2TypeMetadata, XMLTypeMetadata typeMetadata)
        {
            dtg2TypeMetadata.TypeName = typeMetadata.TypeName;
            dtg2TypeMetadata.DeclaringType = EmitDeclaringTypeDTG(typeMetadata.DeclaringType);
            dtg2TypeMetadata.Constructors = SerializationMethodMapper.EmitMethodsDTG(typeMetadata.ConstructorsL);
            dtg2TypeMetadata.Methods = SerializationMethodMapper.EmitMethodsDTG(typeMetadata.MethodsL);
            dtg2TypeMetadata.NestedTypes = EmitNestedTypesDTG(typeMetadata.NestedTypesL);
            dtg2TypeMetadata.ImplementedInterfaces = EmitImplementsDTG(typeMetadata.ImplementedInterfacesL);
            if (typeMetadata.GenericArguments != null)
                dtg2TypeMetadata.GenericArguments = EmitGenericArgumentsDTG(typeMetadata.GenericArguments);
            else dtg2TypeMetadata.GenericArguments = null;
            //dtg2TypeMetadata.Modifiers = EmitModifiers(typeMetadata);
            dtg2TypeMetadata.BaseType = EmitExtendsDTG(typeMetadata.BaseType);
            dtg2TypeMetadata.Properties = SerializationPropertyMapper.EmitPropertiesDTG(typeMetadata.PropertiesL);

            return dtg2TypeMetadata;
        }

        public static IEnumerable<DTGTypeMetadata> CheckGenericArgumentsDTG(XMLTypeMetadata typeMetadata)
        {
            if (typeMetadata.GenericArgumentsL != null)
                return EmitGenericArgumentsDTG(typeMetadata.GenericArgumentsL);
            return null;
        }

        internal static DTGTypeMetadata EmitReferenceDTG(XMLTypeMetadata type)
        {
            if (type == null) return null;
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
        internal static IEnumerable<DTGTypeMetadata> EmitGenericArgumentsDTG(IEnumerable<XMLTypeMetadata> arguments)
        {
            if (arguments == null) return null;
            return from XMLTypeMetadata _argument in arguments select EmitReferenceDTG(_argument);
        }

        private static DTGTypeMetadata EmitDeclaringTypeDTG(XMLTypeMetadata declaringType)
        {
            if (declaringType == null)
                return null;
            return EmitReferenceDTG(declaringType);
        }
        private static IEnumerable<DTGTypeMetadata> EmitNestedTypesDTG(IEnumerable<XMLTypeMetadata> nestedTypes)
        {
            if (nestedTypes == null) return null;
            return from _type in nestedTypes
                   select MapToDTG(_type);
        }
        private static IEnumerable<DTGTypeMetadata> EmitImplementsDTG(IEnumerable<XMLTypeMetadata> interfaces)
        {
            if (interfaces == null) return null;
            return from currentInterface in interfaces
                   select EmitReferenceDTG(currentInterface);
        }
        private static DTGTypeMetadata EmitExtendsDTG(XMLTypeMetadata baseType)
        {
            if (baseType == null)
                return null;
            return EmitReferenceDTG(baseType);
        }
    }
}
