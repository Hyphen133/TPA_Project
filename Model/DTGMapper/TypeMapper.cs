using DataTransferGraph2.Model;
using Logic.Model;
using System.Collections.Generic;
using System.Linq;

namespace Logic.DTGMapper
{
    public class TypeMapper
    {
        public static DTG2TypeMetadata MapToDTGModel(TypeMetadata typeMetadata)
        {
            DTG2TypeMetadata dTG2TypeMetadata = new DTG2TypeMetadata
            {
                TypeName = typeMetadata.TypeName,
                DeclaringType = EmitDeclaringType(typeMetadata.DeclaringType),
                Constructors = MethodMapper.EmitMethods(typeMetadata.Constructors),
                Methods = MethodMapper.EmitMethods(typeMetadata.Methods),
                NestedTypes = EmitNestedTypes(typeMetadata.NestedTypes),
                ImplementedInterfaces = EmitImplements(typeMetadata.ImplementedInterfaces),
                GenericArguments = CheckGenericArguments(typeMetadata),
                BaseType = EmitExtends(typeMetadata.BaseType),
                Properties = PropertyMapper.EmitProperties(typeMetadata.Properties),
                IsGenericType = typeMetadata.IsGenericType
            };

            return dTG2TypeMetadata;
        }

        public static DTG2TypeMetadata fillType(DTG2TypeMetadata dtg2TypeMetadata, TypeMetadata typeMetadata)
        {
            dtg2TypeMetadata.TypeName = typeMetadata.TypeName;
            dtg2TypeMetadata.DeclaringType = EmitDeclaringType(typeMetadata.DeclaringType);
            dtg2TypeMetadata.Constructors = MethodMapper.EmitMethods(typeMetadata.Constructors);
            dtg2TypeMetadata.Methods = MethodMapper.EmitMethods(typeMetadata.Methods);
            dtg2TypeMetadata.NestedTypes = EmitNestedTypes(typeMetadata.NestedTypes);
            dtg2TypeMetadata.ImplementedInterfaces = EmitImplements(typeMetadata.ImplementedInterfaces);
            if (typeMetadata.GenericArguments != null)
                dtg2TypeMetadata.GenericArguments = EmitGenericArguments(typeMetadata.GenericArguments);
            else dtg2TypeMetadata.GenericArguments = null;
            //dtg2TypeMetadata.Modifiers = EmitModifiers(typeMetadata);
            dtg2TypeMetadata.BaseType = EmitExtends(typeMetadata.BaseType);
            dtg2TypeMetadata.Properties = PropertyMapper.EmitProperties(typeMetadata.Properties);

            return dtg2TypeMetadata;
        }

        public static IEnumerable<DTG2TypeMetadata> CheckGenericArguments(TypeMetadata typeMetadata)
        {
            if (typeMetadata.GenericArguments != null)
                return EmitGenericArguments(typeMetadata.GenericArguments);
            return null;
        }

        internal static DTG2TypeMetadata EmitReference(TypeMetadata type)
        {
            if (HelperDictonaries.TypeDictonary.ContainsKey(type))
            {
                return HelperDictonaries.TypeDictonary[type];
            }


            if (!type.IsGenericType)
            {
                HelperDictonaries.TypeDictonary[type] = MapToDTGModel(type);

                return HelperDictonaries.TypeDictonary[type];
            }
            else
                return TypeMapper.MapToDTGModel(type);
        }
        internal static IEnumerable<DTG2TypeMetadata> EmitGenericArguments(IEnumerable<TypeMetadata> arguments)
        {
            return from TypeMetadata _argument in arguments select EmitReference(_argument);
        }

        private static DTG2TypeMetadata EmitDeclaringType(TypeMetadata declaringType)
        {
            if (declaringType == null)
                return null;
            return EmitReference(declaringType);
        }
        private static IEnumerable<DTG2TypeMetadata> EmitNestedTypes(IEnumerable<TypeMetadata> nestedTypes)
        {
            return from _type in nestedTypes
                   select MapToDTGModel(_type);
        }
        private static IEnumerable<DTG2TypeMetadata> EmitImplements(IEnumerable<TypeMetadata> interfaces)
        {
            return from currentInterface in interfaces
                   select EmitReference(currentInterface);
        }
        private static DTG2TypeMetadata EmitExtends(TypeMetadata baseType)
        {
            if (baseType == null)
                return null;
            return EmitReference(baseType);
        }
    }
}
