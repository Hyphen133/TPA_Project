using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataSerializer.Model
{
    [DataContract(IsReference = true)]
    public class XMLTypeMetadata
    {
        [DataMember]
        private string m_typeName;
        [DataMember]
        private string m_NamespaceName;
        [DataMember]
        private XMLTypeMetadata m_BaseType;
        [DataMember]
        private List<XMLTypeMetadata> m_GenericArguments;
        [DataMember]
        private bool m_isGenericType;
        [DataMember]
        private List<XMLTypeMetadata> m_ImplementedInterfaces;
        [DataMember]
        private List<XMLTypeMetadata> m_NestedTypes;
        [DataMember]
        private List<XMLPropertyMetadata> m_Properties;
        [DataMember]
        private XMLTypeMetadata m_DeclaringType;
        [DataMember]
        private List<XMLMethodMetadata> m_Methods;
        [DataMember]
        private List<XMLMethodMetadata> m_Constructors;

        
        public string TypeName { get => m_typeName; set => m_typeName = value; }
        public string NamespaceName { get => m_NamespaceName; set => m_NamespaceName = value; }
        public XMLTypeMetadata BaseType { get => m_BaseType; set => m_BaseType = value; }
        public List<XMLTypeMetadata> GenericArguments { get => m_GenericArguments; set => m_GenericArguments = value; }
        public bool IsGenericType { get => m_isGenericType; set => m_isGenericType = value; }
        public List<XMLTypeMetadata> ImplementedInterfaces { get => m_ImplementedInterfaces; set => m_ImplementedInterfaces = value; }
        public List<XMLTypeMetadata> NestedTypes { get => m_NestedTypes; set => m_NestedTypes = value; }
        public List<XMLPropertyMetadata> Properties { get => m_Properties; set => m_Properties = value; }
        public XMLTypeMetadata DeclaringType { get => m_DeclaringType; set => m_DeclaringType = value; }
        public List<XMLMethodMetadata> Methods { get => m_Methods; set => m_Methods = value; }
        public List<XMLMethodMetadata> Constructors { get => m_Constructors; set => m_Constructors = value; }
    }
}