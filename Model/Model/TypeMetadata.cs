using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Model
{
    public class TypeMetadata
    {
        public TypeMetadata() { }

        #region constructors
        public TypeMetadata(Type type)
        {
            m_typeName = type.Name;
            m_DeclaringType = EmitDeclaringType(type.DeclaringType);
            m_Constructors = MethodMetadata.EmitMethods(type.GetConstructors());
            m_Methods = MethodMetadata.EmitMethods(type.GetMethods());
            m_NestedTypes = EmitNestedTypes(type.GetNestedTypes());
            m_ImplementedInterfaces = EmitImplements(type.GetInterfaces());
            m_GenericArguments = !type.IsGenericTypeDefinition ? null : TypeMetadata.EmitGenericArguments(type.GetGenericArguments());
            m_Modifiers = EmitModifiers(type);
            m_BaseType = EmitExtends(type.BaseType);
            m_Properties = PropertyMetadata.EmitProperties(type.GetProperties());
            m_TypeKind = GetTypeKind(type);
            m_isGenericType = type.IsGenericType;

        }

        public static TypeMetadata fillType(TypeMetadata typeMetadata, Type type)
        {
            typeMetadata.TypeName = type.Name;
            typeMetadata.DeclaringType = EmitDeclaringType(type.DeclaringType);
            typeMetadata.Constructors = MethodMetadata.EmitMethods(type.GetConstructors());
            typeMetadata.Methods = MethodMetadata.EmitMethods(type.GetMethods());
            typeMetadata.NestedTypes = EmitNestedTypes(type.GetNestedTypes());
            typeMetadata.ImplementedInterfaces = EmitImplements(type.GetInterfaces());
            typeMetadata.GenericArguments = !type.IsGenericTypeDefinition ? null : TypeMetadata.EmitGenericArguments(type.GetGenericArguments());
            typeMetadata.Modifiers = EmitModifiers(type);
            typeMetadata.BaseType = EmitExtends(type.BaseType);
            typeMetadata.Properties = PropertyMetadata.EmitProperties(type.GetProperties());
            typeMetadata.IsGenericType = type.IsGenericType;
            return typeMetadata;
        }
        #endregion

        #region API
        public enum TypeKind
        {
            EnumType, StructType, InterfaceType, ClassType
        }
        internal static TypeMetadata EmitReference(Type type)
        {
            if (HelperDictonaries.TypeDictonary.ContainsKey(type))
            {
                return HelperDictonaries.TypeDictonary[type];
            }


            if (!type.IsGenericType)
            {
                HelperDictonaries.TypeDictonary[type] = new TypeMetadata(type);

                return HelperDictonaries.TypeDictonary[type];
            }
            else
            {
                return new TypeMetadata(type.Name, type.Namespace, EmitGenericArguments(type.GetGenericArguments()));
            }
        }
        internal static IEnumerable<TypeMetadata> EmitGenericArguments(IEnumerable<Type> arguments)
        {
            return from Type _argument in arguments select EmitReference(_argument);
        }
        #endregion

        #region private
        private string m_typeName;
        private string m_NamespaceName;
        private TypeMetadata m_BaseType;
        private IEnumerable<TypeMetadata> m_GenericArguments;
        private Tuple<AccessLevel, SealedEnum, AbstractEnum> m_Modifiers;
        private TypeKind m_TypeKind;
        private bool m_isGenericType;
        private IEnumerable<TypeMetadata> m_ImplementedInterfaces;
        private IEnumerable<TypeMetadata> m_NestedTypes;
        private IEnumerable<PropertyMetadata> m_Properties;
        private TypeMetadata m_DeclaringType;
        private IEnumerable<MethodMetadata> m_Methods;
        private IEnumerable<MethodMetadata> m_Constructors;

        public string TypeName { get => m_typeName; set => m_typeName = value; }
        public string NamespaceName { get => m_NamespaceName; set => m_NamespaceName = value; }
        public TypeMetadata BaseType { get => m_BaseType; set => m_BaseType = value; }
        public IEnumerable<TypeMetadata> GenericArguments { get => m_GenericArguments; set => m_GenericArguments = value; }
        public Tuple<AccessLevel, SealedEnum, AbstractEnum> Modifiers { get => m_Modifiers; set => m_Modifiers = value; }
        public TypeKind TypeKind1 { get => m_TypeKind; set => m_TypeKind = value; }
        public bool IsGenericType { get => m_isGenericType; set => m_isGenericType = value; }
        public IEnumerable<TypeMetadata> ImplementedInterfaces { get => m_ImplementedInterfaces; set => m_ImplementedInterfaces = value; }
        public IEnumerable<TypeMetadata> NestedTypes { get => m_NestedTypes; set => m_NestedTypes = value; }
        public IEnumerable<PropertyMetadata> Properties { get => m_Properties; set => m_Properties = value; }
        public TypeMetadata DeclaringType { get => m_DeclaringType; set => m_DeclaringType = value; }
        public IEnumerable<MethodMetadata> Methods { get => m_Methods; set => m_Methods = value; }
        public IEnumerable<MethodMetadata> Constructors { get => m_Constructors; set => m_Constructors = value; }

        //constructors
        public TypeMetadata(string typeName, string namespaceName)
        {
            m_typeName = typeName;
            m_NamespaceName = namespaceName;
        }
        public TypeMetadata(string typeName, string namespaceName, IEnumerable<TypeMetadata> genericArguments) : this(typeName, namespaceName)
        {
            m_GenericArguments = genericArguments;
        }
        //methods
        private static TypeMetadata EmitDeclaringType(Type declaringType)
        {
            if (declaringType == null)
                return null;
            return EmitReference(declaringType);
        }
        private static IEnumerable<TypeMetadata> EmitNestedTypes(IEnumerable<Type> nestedTypes)
        {
            return from _type in nestedTypes
                   where _type.IsVisible
                   select new TypeMetadata(_type);
        }
        private static IEnumerable<TypeMetadata> EmitImplements(IEnumerable<Type> interfaces)
        {
            return from currentInterface in interfaces
                   select EmitReference(currentInterface);
        }
        private static TypeKind GetTypeKind(Type type) //#80 TPA: Reflection - Invalid return value of GetTypeKind() 
        {
            return type.IsEnum ? TypeKind.EnumType :
                   type.IsValueType ? TypeKind.StructType :
                   type.IsInterface ? TypeKind.InterfaceType :
                   TypeKind.ClassType;
        }
        static Tuple<AccessLevel, SealedEnum, AbstractEnum> EmitModifiers(Type type)
        {
            //set defaults 
            AccessLevel _access = AccessLevel.IsPrivate;
            AbstractEnum _abstract = AbstractEnum.NotAbstract;
            SealedEnum _sealed = SealedEnum.NotSealed;
            // check if not default 
            if (type.IsPublic)
                _access = AccessLevel.IsPublic;
            else if (type.IsNestedPublic)
                _access = AccessLevel.IsPublic;
            else if (type.IsNestedFamily)
                _access = AccessLevel.IsProtected;
            else if (type.IsNestedFamANDAssem)
                _access = AccessLevel.IsProtectedInternal;
            if (type.IsSealed)
                _sealed = SealedEnum.Sealed;
            if (type.IsAbstract)
                _abstract = AbstractEnum.Abstract;
            return new Tuple<AccessLevel, SealedEnum, AbstractEnum>(_access, _sealed, _abstract);
        }
        private static TypeMetadata EmitExtends(Type baseType)
        {
            if (baseType == null || baseType == typeof(Object) || baseType == typeof(ValueType) || baseType == typeof(Enum))
                return null;
            return EmitReference(baseType);
        }
        #endregion

    }
}