using DataTransferGraph.Model;
using Logic.Model;
using System.Collections.Generic;
using System.Linq;

namespace Logic.DTGMapper
{
    public class TypeMapper
    {
        public static DTGTypeMetadata MapToDTGModel(TypeMetadata typeMetadata)
        {
            DTGTypeMetadata dTG2TypeMetadata = new DTGTypeMetadata
            {
                TypeName = typeMetadata.TypeName,
                DeclaringType = EmitDeclaringTypeDTG(typeMetadata.DeclaringType),
                Constructors = MethodMapper.EmitMethodsDTG(typeMetadata.Constructors),
                Methods = MethodMapper.EmitMethodsDTG(typeMetadata.Methods),
                NestedTypes = EmitNestedTypesDTG(typeMetadata.NestedTypes),
                ImplementedInterfaces = EmitImplementsDTG(typeMetadata.ImplementedInterfaces),
                GenericArguments = CheckGenericArgumentsDTG(typeMetadata),
                BaseType = EmitExtendsDTG(typeMetadata.BaseType),
                Properties = PropertyMapper.EmitPropertiesDTG(typeMetadata.Properties),
                IsGenericType = typeMetadata.IsGenericType
            };

            return dTG2TypeMetadata;
        }

        public static DTGTypeMetadata FillTypeDTG(DTGTypeMetadata dtg2TypeMetadata, TypeMetadata typeMetadata)
        {
            dtg2TypeMetadata.TypeName = typeMetadata.TypeName;
            dtg2TypeMetadata.DeclaringType = EmitDeclaringTypeDTG(typeMetadata.DeclaringType);
            dtg2TypeMetadata.Constructors = MethodMapper.EmitMethodsDTG(typeMetadata.Constructors);
            dtg2TypeMetadata.Methods = MethodMapper.EmitMethodsDTG(typeMetadata.Methods);
            dtg2TypeMetadata.NestedTypes = EmitNestedTypesDTG(typeMetadata.NestedTypes);
            dtg2TypeMetadata.ImplementedInterfaces = EmitImplementsDTG(typeMetadata.ImplementedInterfaces);
            if (typeMetadata.GenericArguments != null)
                dtg2TypeMetadata.GenericArguments = EmitGenericArgumentsDTG(typeMetadata.GenericArguments);
            else dtg2TypeMetadata.GenericArguments = null;
            //dtg2TypeMetadata.Modifiers = EmitModifiers(typeMetadata);
            dtg2TypeMetadata.BaseType = EmitExtendsDTG(typeMetadata.BaseType);
            dtg2TypeMetadata.Properties = PropertyMapper.EmitPropertiesDTG(typeMetadata.Properties);

            return dtg2TypeMetadata;
        }

        public static IEnumerable<DTGTypeMetadata> CheckGenericArgumentsDTG(TypeMetadata typeMetadata)
        {
            if (typeMetadata.GenericArguments != null)
                return EmitGenericArgumentsDTG(typeMetadata.GenericArguments);
            return null;
        }

        internal static DTGTypeMetadata EmitReferenceDTG(TypeMetadata type)
        {
            if (type == null) return null;
            if (HelperDictonaries.TypeDictonaryForDTG.ContainsKey(type))
            {
                return HelperDictonaries.TypeDictonaryForDTG[type];
            }


            if (!type.IsGenericType)
            {
                HelperDictonaries.TypeDictonaryForDTG[type] = MapToDTGModel(type);

                return HelperDictonaries.TypeDictonaryForDTG[type];
            }
            else
                return TypeMapper.MapToDTGModel(type);
        }
        internal static IEnumerable<DTGTypeMetadata> EmitGenericArgumentsDTG(IEnumerable<TypeMetadata> arguments)
        {
            if (arguments == null) return null;
            return from TypeMetadata _argument in arguments select EmitReferenceDTG(_argument);
        }

        private static DTGTypeMetadata EmitDeclaringTypeDTG(TypeMetadata declaringType)
        {
            if (declaringType == null)
                return null;
            return EmitReferenceDTG(declaringType);
        }
        private static IEnumerable<DTGTypeMetadata> EmitNestedTypesDTG(IEnumerable<TypeMetadata> nestedTypes)
        {
            if (nestedTypes == null) return null;
            return from _type in nestedTypes
                   select MapToDTGModel(_type);
        }
        private static IEnumerable<DTGTypeMetadata> EmitImplementsDTG(IEnumerable<TypeMetadata> interfaces)
        {
            if (interfaces == null) return null;
            return from currentInterface in interfaces
                   select EmitReferenceDTG(currentInterface);
        }
        private static DTGTypeMetadata EmitExtendsDTG(TypeMetadata baseType)
        {
            if (baseType == null)
                return null;
            return EmitReferenceDTG(baseType);
        }

        public static TypeMetadata MapToModel(DTGTypeMetadata typeMetadata)
        {
            TypeMetadata dTG2TypeMetadata = new TypeMetadata
            {
                TypeName = typeMetadata.TypeName,
                DeclaringType = EmitDeclaringTypeModel(typeMetadata.DeclaringType),
                Constructors = MethodMapper.EmitMethodsModel(typeMetadata.Constructors),
                Methods = MethodMapper.EmitMethodsModel(typeMetadata.Methods),
                NestedTypes = EmitNestedTypesModel(typeMetadata.NestedTypes),
                ImplementedInterfaces = EmitImplementsModel(typeMetadata.ImplementedInterfaces),
                GenericArguments = CheckGenericArgumentsModel(typeMetadata),
                BaseType = EmitExtendsModel(typeMetadata.BaseType),
                Properties = PropertyMapper.EmitPropertiesModel(typeMetadata.Properties),
                IsGenericType = typeMetadata.IsGenericType
            };

            return dTG2TypeMetadata;
        }

        public static TypeMetadata FillTypeModel(TypeMetadata dtg2TypeMetadata, DTGTypeMetadata typeMetadata)
        {
            dtg2TypeMetadata.TypeName = typeMetadata.TypeName;
            dtg2TypeMetadata.DeclaringType = EmitDeclaringTypeModel(typeMetadata.DeclaringType);
            dtg2TypeMetadata.Constructors = MethodMapper.EmitMethodsModel(typeMetadata.Constructors);
            dtg2TypeMetadata.Methods = MethodMapper.EmitMethodsModel(typeMetadata.Methods);
            dtg2TypeMetadata.NestedTypes = EmitNestedTypesModel(typeMetadata.NestedTypes);
            dtg2TypeMetadata.ImplementedInterfaces = EmitImplementsModel(typeMetadata.ImplementedInterfaces);
            if (typeMetadata.GenericArguments != null)
                dtg2TypeMetadata.GenericArguments = EmitGenericArgumentsModel(typeMetadata.GenericArguments);
            else dtg2TypeMetadata.GenericArguments = null;
            //dtg2TypeMetadata.Modifiers = EmitModifiers(typeMetadata);
            dtg2TypeMetadata.BaseType = EmitExtendsModel(typeMetadata.BaseType);
            dtg2TypeMetadata.Properties = PropertyMapper.EmitPropertiesModel(typeMetadata.Properties);

            return dtg2TypeMetadata;
        }

        public static IEnumerable<TypeMetadata> CheckGenericArgumentsModel(DTGTypeMetadata typeMetadata)
        {
            if (typeMetadata.GenericArguments != null)
                return EmitGenericArgumentsModel(typeMetadata.GenericArguments);
            return null;
        }

        internal static TypeMetadata EmitReferenceModel(DTGTypeMetadata type)
        {
            if (type == null) return null;
            if (HelperDictonaries.TypeDictonaryForModel.ContainsKey(type))
            {
                return HelperDictonaries.TypeDictonaryForModel[type];
            }


            if (!type.IsGenericType)
            {
                HelperDictonaries.TypeDictonaryForModel[type] = MapToModel(type);

                return HelperDictonaries.TypeDictonaryForModel[type];
            }
            else
                return TypeMapper.MapToModel(type);
        }
        internal static IEnumerable<TypeMetadata> EmitGenericArgumentsModel(IEnumerable<DTGTypeMetadata> arguments)
        {
            if (arguments == null) return null;
            return from DTGTypeMetadata _argument in arguments select EmitReferenceModel(_argument);
        }

        private static TypeMetadata EmitDeclaringTypeModel(DTGTypeMetadata declaringType)
        {
            if (declaringType == null)
                return null;
            return EmitReferenceModel(declaringType);
        }
        private static IEnumerable<TypeMetadata> EmitNestedTypesModel(IEnumerable<DTGTypeMetadata> nestedTypes)
        {
            if (nestedTypes == null) return null;
            return from _type in nestedTypes
                   select MapToModel(_type);
        }
        private static IEnumerable<TypeMetadata> EmitImplementsModel(IEnumerable<DTGTypeMetadata> interfaces)
        {
            if(interfaces == null)
            {
                return null;
            }
            return from currentInterface in interfaces
                   select EmitReferenceModel(currentInterface);
        }
        private static TypeMetadata EmitExtendsModel(DTGTypeMetadata baseType)
        {
            if (baseType == null)
                return null;
            return EmitReferenceModel(baseType);
        }


    }
}
