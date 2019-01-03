using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataSerializer.Model
{
    [DataContract(IsReference = true)]
    public class XMLTypeMetadata
    {
        private string m_typeName;
        private string m_NamespaceName;
        private XMLTypeMetadata m_BaseType;
        private IEnumerable<XMLTypeMetadata> m_GenericArguments;
        //private Tuple<AccessLevel, SealedEnum, AbstractEnum> m_Modifiers;
        //private TypeKind m_TypeKind;
        private bool m_isGenericType;
        private IEnumerable<XMLTypeMetadata> m_ImplementedInterfaces;
        private IEnumerable<XMLTypeMetadata> m_NestedTypes;
        private IEnumerable<XMLPropertyMetadata> m_Properties;
        private XMLTypeMetadata m_DeclaringType;
        private IEnumerable<XMLMethodMetadata> m_Methods;
        private IEnumerable<XMLMethodMetadata> m_Constructors;

        public string TypeName { get => m_typeName; set => m_typeName = value; }
        public string NamespaceName { get => m_NamespaceName; set => m_NamespaceName = value; }
        public XMLTypeMetadata BaseType { get => m_BaseType; set => m_BaseType = value; }
        public IEnumerable<XMLTypeMetadata> GenericArguments { get => m_GenericArguments; set => m_GenericArguments = value; }
        //public Tuple<AccessLevel, SealedEnum, AbstractEnum> Modifiers { get => m_Modifiers; set => m_Modifiers = value; }
        //public TypeKind TypeKind1 { get => m_TypeKind; set => m_TypeKind = value; }
        public bool IsGenericType { get => m_isGenericType; set => m_isGenericType = value; }
        public IEnumerable<XMLTypeMetadata> ImplementedInterfaces { get => m_ImplementedInterfaces; set => m_ImplementedInterfaces = value; }
        public IEnumerable<XMLTypeMetadata> NestedTypes { get => m_NestedTypes; set => m_NestedTypes = value; }
        public IEnumerable<XMLPropertyMetadata> Properties { get => m_Properties; set => m_Properties = value; }
        public XMLTypeMetadata DeclaringType { get => m_DeclaringType; set => m_DeclaringType = value; }
        public IEnumerable<XMLMethodMetadata> Methods { get => m_Methods; set => m_Methods = value; }
        public IEnumerable<XMLMethodMetadata> Constructors { get => m_Constructors; set => m_Constructors = value; }
    }
}
