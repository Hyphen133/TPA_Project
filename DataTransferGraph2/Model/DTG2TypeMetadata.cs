using System.Collections.Generic;

namespace DataTransferGraph2.Model
{
    public class DTG2TypeMetadata
    {
        private string m_typeName;
        private string m_NamespaceName;
        private DTG2TypeMetadata m_BaseType;
        private IEnumerable<DTG2TypeMetadata> m_GenericArguments;
        //private Tuple<AccessLevel, SealedEnum, AbstractEnum> m_Modifiers;
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
        //public Tuple<AccessLevel, SealedEnum, AbstractEnum> Modifiers { get => m_Modifiers; set => m_Modifiers = value; }
        //public TypeKind TypeKind1 { get => m_TypeKind; set => m_TypeKind = value; }
        public bool IsGenericType { get => m_isGenericType; set => m_isGenericType = value; }
        public IEnumerable<DTG2TypeMetadata> ImplementedInterfaces { get => m_ImplementedInterfaces; set => m_ImplementedInterfaces = value; }
        public IEnumerable<DTG2TypeMetadata> NestedTypes { get => m_NestedTypes; set => m_NestedTypes = value; }
        public IEnumerable<DTG2PropertyMetadata> Properties { get => m_Properties; set => m_Properties = value; }
        public DTG2TypeMetadata DeclaringType { get => m_DeclaringType; set => m_DeclaringType = value; }
        public IEnumerable<DTG2MethodMetadata> Methods { get => m_Methods; set => m_Methods = value; }
        public IEnumerable<DTG2MethodMetadata> Constructors { get => m_Constructors; set => m_Constructors = value; }
    }
}