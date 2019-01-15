using System.Collections.Generic;

namespace DataTransferGraph.Model
{
    public class DTGTypeMetadata
    {
        private string m_typeName;
        private string m_NamespaceName;
        private DTGTypeMetadata m_BaseType;
        private IEnumerable<DTGTypeMetadata> m_GenericArguments;
        //private Tuple<AccessLevel, SealedEnum, AbstractEnum> m_Modifiers;
        //private TypeKind m_TypeKind;
        private bool m_isGenericType;
        private IEnumerable<DTGTypeMetadata> m_ImplementedInterfaces;
        private IEnumerable<DTGTypeMetadata> m_NestedTypes;
        private IEnumerable<DTGPropertyMetadata> m_Properties;
        private DTGTypeMetadata m_DeclaringType;
        private IEnumerable<DTGMethodMetadata> m_Methods;
        private IEnumerable<DTGMethodMetadata> m_Constructors;

        public string TypeName { get => m_typeName; set => m_typeName = value; }
        public string NamespaceName { get => m_NamespaceName; set => m_NamespaceName = value; }
        public DTGTypeMetadata BaseType { get => m_BaseType; set => m_BaseType = value; }
        public IEnumerable<DTGTypeMetadata> GenericArguments { get => m_GenericArguments; set => m_GenericArguments = value; }
        //public Tuple<AccessLevel, SealedEnum, AbstractEnum> Modifiers { get => m_Modifiers; set => m_Modifiers = value; }
        //public TypeKind TypeKind1 { get => m_TypeKind; set => m_TypeKind = value; }
        public bool IsGenericType { get => m_isGenericType; set => m_isGenericType = value; }
        public IEnumerable<DTGTypeMetadata> ImplementedInterfaces { get => m_ImplementedInterfaces; set => m_ImplementedInterfaces = value; }
        public IEnumerable<DTGTypeMetadata> NestedTypes { get => m_NestedTypes; set => m_NestedTypes = value; }
        public IEnumerable<DTGPropertyMetadata> Properties { get => m_Properties; set => m_Properties = value; }
        public DTGTypeMetadata DeclaringType { get => m_DeclaringType; set => m_DeclaringType = value; }
        public IEnumerable<DTGMethodMetadata> Methods { get => m_Methods; set => m_Methods = value; }
        public IEnumerable<DTGMethodMetadata> Constructors { get => m_Constructors; set => m_Constructors = value; }
    }
}