using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Data
{
    [DataContract(IsReference = true)]
    public class TypeMetadata
    {
        #region API
        public enum TypeKind
        {
            [EnumMember]
            EnumType,
            [EnumMember]
            StructType,
            [EnumMember]
            InterfaceType,
            [EnumMember]
            ClassType
        }
        #endregion

        #region private
        [DataMember]
        private string m_typeName;
        [DataMember]
        private string m_NamespaceName;
        [DataMember]
        private TypeMetadata m_BaseType;
        [DataMember]
        private IEnumerable<TypeMetadata> m_GenericArguments;
        [DataMember]
        private Tuple<AccessLevel, SealedEnum, AbstractEnum> m_Modifiers;
        [DataMember]
        private TypeKind m_TypeKind;
        [DataMember]
        private IEnumerable<TypeMetadata> m_ImplementedInterfaces;
        [DataMember]
        private IEnumerable<TypeMetadata> m_NestedTypes;
        [DataMember]
        private IEnumerable<PropertyMetadata> m_Properties;
        [DataMember]
        private TypeMetadata m_DeclaringType;
        [DataMember]
        private IEnumerable<MethodMetadata> m_Methods;
        [DataMember]
        private IEnumerable<MethodMetadata> m_Constructors;

        public string TypeName { get => m_typeName; set => m_typeName = value; }
        public string NamespaceName { get => m_NamespaceName; set => m_NamespaceName = value; }
        public TypeMetadata BaseType { get => m_BaseType; set => m_BaseType = value; }
        public IEnumerable<TypeMetadata> GenericArguments { get => m_GenericArguments; set => m_GenericArguments = value; }
        public Tuple<AccessLevel, SealedEnum, AbstractEnum> Modifiers { get => m_Modifiers; set => m_Modifiers = value; }
        public TypeKind TypeKind1 { get => m_TypeKind; set => m_TypeKind = value; }
        public IEnumerable<TypeMetadata> ImplementedInterfaces { get => m_ImplementedInterfaces; set => m_ImplementedInterfaces = value; }
        public IEnumerable<TypeMetadata> NestedTypes { get => m_NestedTypes; set => m_NestedTypes = value; }
        public IEnumerable<PropertyMetadata> Properties { get => m_Properties; set => m_Properties = value; }
        public TypeMetadata DeclaringType { get => m_DeclaringType; set => m_DeclaringType = value; }
        public IEnumerable<MethodMetadata> Methods { get => m_Methods; set => m_Methods = value; }
        public IEnumerable<MethodMetadata> Constructors { get => m_Constructors; set => m_Constructors = value; }
        #endregion
    }
}