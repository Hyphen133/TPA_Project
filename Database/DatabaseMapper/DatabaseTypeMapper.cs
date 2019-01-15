using Database.Model;
using DataTransferGraph.Model;
using System.Collections.Generic;
using System.Linq;

namespace Database.DatabaseMapper
{
    public class SerializationTypeMapper
    {
        public static DatabaseTypeMetadata MapToDatabase(DTGTypeMetadata typeMetadata)
        {
            DatabaseTypeMetadata DatabaseTypeMetadata = new DatabaseTypeMetadata
            {
                TypeName = typeMetadata.TypeName,
                DeclaringType = EmitDeclaringTypeDatabase(typeMetadata.DeclaringType),
                Constructors = DatabaseMethodMapper.EmitMethodsDatabase(typeMetadata.Constructors),
                Methods = DatabaseMethodMapper.EmitMethodsDatabase(typeMetadata.Methods),
                NestedTypes = EmitNestedTypesDatabase(typeMetadata.NestedTypes),
                ImplementedInterfaces = EmitImplementsDatabase(typeMetadata.ImplementedInterfaces),
                GenericArguments = CheckGenericArgumentsDatabase(typeMetadata),
                BaseType = EmitExtendsDatabase(typeMetadata.BaseType),
                Properties = DatabasePropertyMapper.EmitPropertiesDatabase(typeMetadata.Properties),
                IsGenericType = typeMetadata.IsGenericType
            };

            return DatabaseTypeMetadata;
        }

        public static DatabaseTypeMetadata FillTypeDatabase(DatabaseTypeMetadata DTGTypeMetadata, DTGTypeMetadata typeMetadata)
        {
            DTGTypeMetadata.TypeName = typeMetadata.TypeName;
            DTGTypeMetadata.DeclaringType = EmitDeclaringTypeDatabase(typeMetadata.DeclaringType);
            DTGTypeMetadata.Constructors = DatabaseMethodMapper.EmitMethodsDatabase(typeMetadata.Constructors);
            DTGTypeMetadata.Methods = DatabaseMethodMapper.EmitMethodsDatabase(typeMetadata.Methods);
            DTGTypeMetadata.NestedTypes = EmitNestedTypesDatabase(typeMetadata.NestedTypes);
            DTGTypeMetadata.ImplementedInterfaces = EmitImplementsDatabase(typeMetadata.ImplementedInterfaces);
            if (typeMetadata.GenericArguments != null)
                DTGTypeMetadata.GenericArguments = EmitGenericArgumentsDatabase(typeMetadata.GenericArguments);
            else DTGTypeMetadata.GenericArguments = null;
            //DTGTypeMetadata.Modifiers = EmitModifiers(typeMetadata);
            DTGTypeMetadata.BaseType = EmitExtendsDatabase(typeMetadata.BaseType);
            DTGTypeMetadata.Properties = DatabasePropertyMapper.EmitPropertiesDatabase(typeMetadata.Properties);

            return DTGTypeMetadata;
        }

        public static IEnumerable<DatabaseTypeMetadata> CheckGenericArgumentsDatabase(DTGTypeMetadata typeMetadata)
        {
            if (typeMetadata.GenericArguments != null)
                return EmitGenericArgumentsDatabase(typeMetadata.GenericArguments);
            return null;
        }

        internal static DatabaseTypeMetadata EmitReferenceDatabase(DTGTypeMetadata type)
        {
            if (type == null) return null;
            if (HelperDictonaries.TypeDictonaryToDatabase.ContainsKey(type))
            {
                return HelperDictonaries.TypeDictonaryToDatabase[type];
            }


            if (!type.IsGenericType)
            {
                HelperDictonaries.TypeDictonaryToDatabase[type] = MapToDatabase(type);

                return HelperDictonaries.TypeDictonaryToDatabase[type];
            }
            else
                return MapToDatabase(type);
        }
        internal static IEnumerable<DatabaseTypeMetadata> EmitGenericArgumentsDatabase(IEnumerable<DTGTypeMetadata> arguments)
        {
            if (arguments == null) return null;
            return from DTGTypeMetadata _argument in arguments select EmitReferenceDatabase(_argument);
        }

        private static DatabaseTypeMetadata EmitDeclaringTypeDatabase(DTGTypeMetadata declaringType)
        {
            if (declaringType == null)
                return null;
            return EmitReferenceDatabase(declaringType);
        }
        private static IEnumerable<DatabaseTypeMetadata> EmitNestedTypesDatabase(IEnumerable<DTGTypeMetadata> nestedTypes)
        {
            return from _type in nestedTypes
                   select MapToDatabase(_type);
        }
        private static IEnumerable<DatabaseTypeMetadata> EmitImplementsDatabase(IEnumerable<DTGTypeMetadata> interfaces)
        {
            return from currentInterface in interfaces
                   select EmitReferenceDatabase(currentInterface);
        }
        private static DatabaseTypeMetadata EmitExtendsDatabase(DTGTypeMetadata baseType)
        {
            if (baseType == null)
                return null;
            return EmitReferenceDatabase(baseType);
        }






        public static DTGTypeMetadata MapToDTG(DatabaseTypeMetadata typeMetadata)
        {
            DTGTypeMetadata DatabaseTypeMetadata = new DTGTypeMetadata
            {
                TypeName = typeMetadata.TypeName,
                DeclaringType = EmitDeclaringTypeDTG(typeMetadata.DeclaringType),
                Constructors = DatabaseMethodMapper.EmitMethodsDTG(typeMetadata.ConstructorsL),
                Methods = DatabaseMethodMapper.EmitMethodsDTG(typeMetadata.MethodsL),
                NestedTypes = EmitNestedTypesDTG(typeMetadata.NestedTypesL),
                ImplementedInterfaces = EmitImplementsDTG(typeMetadata.ImplementedInterfacesL),
                GenericArguments = CheckGenericArgumentsDTG(typeMetadata),
                BaseType = EmitExtendsDTG(typeMetadata.BaseType),
                Properties = DatabasePropertyMapper.EmitPropertiesDTG(typeMetadata.PropertiesL),
                IsGenericType = typeMetadata.IsGenericType
            };

            return DatabaseTypeMetadata;
        }

        public static DTGTypeMetadata fillType(DTGTypeMetadata DTGTypeMetadata, DatabaseTypeMetadata typeMetadata)
        {
            DTGTypeMetadata.TypeName = typeMetadata.TypeName;
            DTGTypeMetadata.DeclaringType = EmitDeclaringTypeDTG(typeMetadata.DeclaringType);
            DTGTypeMetadata.Constructors = DatabaseMethodMapper.EmitMethodsDTG(typeMetadata.ConstructorsL);
            DTGTypeMetadata.Methods = DatabaseMethodMapper.EmitMethodsDTG(typeMetadata.MethodsL);
            DTGTypeMetadata.NestedTypes = EmitNestedTypesDTG(typeMetadata.NestedTypesL);
            DTGTypeMetadata.ImplementedInterfaces = EmitImplementsDTG(typeMetadata.ImplementedInterfacesL);
            if (typeMetadata.GenericArguments != null)
                DTGTypeMetadata.GenericArguments = EmitGenericArgumentsDTG(typeMetadata.GenericArguments);
            else DTGTypeMetadata.GenericArguments = null;
            //DTGTypeMetadata.Modifiers = EmitModifiers(typeMetadata);
            DTGTypeMetadata.BaseType = EmitExtendsDTG(typeMetadata.BaseType);
            DTGTypeMetadata.Properties = DatabasePropertyMapper.EmitPropertiesDTG(typeMetadata.PropertiesL);

            return DTGTypeMetadata;
        }

        public static IEnumerable<DTGTypeMetadata> CheckGenericArgumentsDTG(DatabaseTypeMetadata typeMetadata)
        {
            if (typeMetadata.GenericArgumentsL != null)
                return EmitGenericArgumentsDTG(typeMetadata.GenericArgumentsL);
            return null;
        }

        internal static DTGTypeMetadata EmitReferenceDTG(DatabaseTypeMetadata type)
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
        internal static IEnumerable<DTGTypeMetadata> EmitGenericArgumentsDTG(IEnumerable<DatabaseTypeMetadata> arguments)
        {
            if (arguments == null) return null;
            return from DatabaseTypeMetadata _argument in arguments select EmitReferenceDTG(_argument);
        }

        private static DTGTypeMetadata EmitDeclaringTypeDTG(DatabaseTypeMetadata declaringType)
        {
            if (declaringType == null)
                return null;
            return EmitReferenceDTG(declaringType);
        }
        private static IEnumerable<DTGTypeMetadata> EmitNestedTypesDTG(IEnumerable<DatabaseTypeMetadata> nestedTypes)
        {
            if (nestedTypes == null) return null;
            return from _type in nestedTypes
                   select MapToDTG(_type);
        }
        private static IEnumerable<DTGTypeMetadata> EmitImplementsDTG(IEnumerable<DatabaseTypeMetadata> interfaces)
        {
            if (interfaces == null) return null;
            return from currentInterface in interfaces
                   select EmitReferenceDTG(currentInterface);
        }
        private static DTGTypeMetadata EmitExtendsDTG(DatabaseTypeMetadata baseType)
        {
            if (baseType == null)
                return null;
            return EmitReferenceDTG(baseType);
        }
    }
}
