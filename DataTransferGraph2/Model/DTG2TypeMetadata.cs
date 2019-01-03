using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataTransferGraph2.Model
{
    public class DTG2TypeMetadata
    {
        public DTG2TypeMetadata() { }

        #region constructors
        public DTG2TypeMetadata(TypeMetadata type)
        {
            m_typeName = type.TypeName;
            m_DeclaringType = EmitDeclaringType(type.DeclaringType);
            m_Constructors = DTG2MethodMetadata.EmitMethods(type.Constructors);
            m_Methods = DTG2MethodMetadata.EmitMethods(type.Methods);
            m_NestedTypes = EmitNestedTypes(type.NestedTypes);
            m_ImplementedInterfaces = EmitImplements(type.ImplementedInterfaces);
            if (type.GenericArguments != null)
                m_GenericArguments = EmitGenericArguments(type.GenericArguments);
            else m_GenericArguments = null;
            //m_Modifiers = EmitModifiers(type);
            m_BaseType = EmitExtends(type.BaseType);
            m_Properties = DTG2PropertyMetadata.EmitProperties(type.Properties);
            //m_TypeKind = GetTypeKind(type);
            m_isGenericType = type.IsGenericType;
        }

        public static DTG2TypeMetadata fillType(DTG2TypeMetadata dtg2TypeMetadata, TypeMetadata typeMetadata)
        {
            dtg2TypeMetadata.TypeName = typeMetadata.TypeName;
            dtg2TypeMetadata.DeclaringType = EmitDeclaringType(typeMetadata.DeclaringType);
            dtg2TypeMetadata.Constructors = DTG2MethodMetadata.EmitMethods(typeMetadata.Constructors);
            dtg2TypeMetadata.Methods = DTG2MethodMetadata.EmitMethods(typeMetadata.Methods);
            dtg2TypeMetadata.NestedTypes = EmitNestedTypes(typeMetadata.NestedTypes);
            dtg2TypeMetadata.ImplementedInterfaces = EmitImplements(typeMetadata.ImplementedInterfaces);
            if (typeMetadata.GenericArguments != null)
                dtg2TypeMetadata.GenericArguments = EmitGenericArguments(typeMetadata.GenericArguments);
            else dtg2TypeMetadata.GenericArguments = null;
            //dtg2TypeMetadata.Modifiers = EmitModifiers(typeMetadata);
            dtg2TypeMetadata.BaseType = EmitExtends(typeMetadata.BaseType);
            dtg2TypeMetadata.Properties = DTG2PropertyMetadata.EmitProperties(typeMetadata.Properties);

            return dtg2TypeMetadata;
        }
        #endregion

        #region API
        public enum TypeKind
        {
            EnumType, StructType, InterfaceType, ClassType
        }
        internal static DTG2TypeMetadata EmitReference(TypeMetadata type)
        {
            if (DTG2HelperDictonaries.TypeDictonary.ContainsKey(type))
            {
                return DTG2HelperDictonaries.TypeDictonary[type];
            }


            if (!type.IsGenericType)
            {
                DTG2HelperDictonaries.TypeDictonary[type] = new DTG2TypeMetadata(type);

                return DTG2HelperDictonaries.TypeDictonary[type];
            }
            else
                return new DTG2TypeMetadata(type.TypeName, type.NamespaceName, EmitGenericArguments(type.GenericArguments));
        }
        internal static IEnumerable<DTG2TypeMetadata> EmitGenericArguments(IEnumerable<TypeMetadata> arguments)
        {
            return from TypeMetadata _argument in arguments select EmitReference(_argument);
        }
        #endregion

        #region private
        private string m_typeName;
        private string m_NamespaceName;
        private DTG2TypeMetadata m_BaseType;
        private IEnumerable<DTG2TypeMetadata> m_GenericArguments;
        private Tuple<AccessLevel, SealedEnum, AbstractEnum> m_Modifiers;
        //private TypeKind m_TypeKind;
        private bool m_isGenericType;
        private IEnumerable<DTG2TypeMetadata> m_ImplementedInterfaces;
        private IEnumerable<DTG2TypeMetadata> m_NestedTypes;
        private IEnumerable<DTG2PropertyMetadata> m_Properties;
        private DTG2TypeMetadata m_DeclaringType;
        private IEnumerable<DTG2MethodMetadata> m_Methods;
        private IEnumerable<DTG2MethodMetadata> m_Constructors;

        public string TypeName { get => m_typeName; set => m_typeName = value; }
        public string NamespaceName { get => m_NamespaceName; set => m_NamespaceName = value; }
        public DTG2TypeMetadata BaseType { get => m_BaseType; set => m_BaseType = value; }
        public IEnumerable<DTG2TypeMetadata> GenericArguments { get => m_GenericArguments; set => m_GenericArguments = value; }
        public Tuple<AccessLevel, SealedEnum, AbstractEnum> Modifiers { get => m_Modifiers; set => m_Modifiers = value; }
        //public TypeKind TypeKind1 { get => m_TypeKind; set => m_TypeKind = value; }
        public bool IsGenericType { get => m_isGenericType; set => m_isGenericType = value; }
        public IEnumerable<DTG2TypeMetadata> ImplementedInterfaces { get => m_ImplementedInterfaces; set => m_ImplementedInterfaces = value; }
        public IEnumerable<DTG2TypeMetadata> NestedTypes { get => m_NestedTypes; set => m_NestedTypes = value; }
        public IEnumerable<DTG2PropertyMetadata> Properties { get => m_Properties; set => m_Properties = value; }
        public DTG2TypeMetadata DeclaringType { get => m_DeclaringType; set => m_DeclaringType = value; }
        public IEnumerable<DTG2MethodMetadata> Methods { get => m_Methods; set => m_Methods = value; }
        public IEnumerable<DTG2MethodMetadata> Constructors { get => m_Constructors; set => m_Constructors = value; }

        //constructors
        public DTG2TypeMetadata(string typeName, string namespaceName)
        {
            m_typeName = typeName;
            m_NamespaceName = namespaceName;
        }
        public DTG2TypeMetadata(string typeName, string namespaceName, IEnumerable<DTG2TypeMetadata> genericArguments) : this(typeName, namespaceName)
        {
            m_GenericArguments = genericArguments;
        }
        //methods
        private static DTG2TypeMetadata EmitDeclaringType(TypeMetadata declaringType)
        {
            if (declaringType == null)
                return null;
            return EmitReference(declaringType);
        }
        private static IEnumerable<DTG2TypeMetadata> EmitNestedTypes(IEnumerable<TypeMetadata> nestedTypes)
        {
            return from _type in nestedTypes
                   select new DTG2TypeMetadata(_type);
        }
        private static IEnumerable<DTG2TypeMetadata> EmitImplements(IEnumerable<TypeMetadata> interfaces)
        {
            return from currentInterface in interfaces
                   select EmitReference(currentInterface);
        }
        /*private static TypeKind GetTypeKind(TypeMetadata type) //#80 TPA: Reflection - Invalid return value of GetTypeKind() 
        {
            return type.IsEnum ? TypeKind.EnumType :
                   type.IsValueType ? TypeKind.StructType :
                   type.IsInterface ? TypeKind.InterfaceType :
                   TypeKind.ClassType;
        }*/
        /*static Tuple<AccessLevel, SealedEnum, AbstractEnum> EmitModifiers(TypeMetadata type)
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
        }*/
        private static DTG2TypeMetadata EmitExtends(TypeMetadata baseType)
        {
            if (baseType == null)
                return null;
            return EmitReference(baseType);
        }
        #endregion

    }
}