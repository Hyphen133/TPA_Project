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
        private XMLTypeMetadata m_BaseType;
        [DataMember]
        private IEnumerable<XMLTypeMetadata> m_GenericArguments;
        [DataMember]
        private bool m_isGenericType;
        [DataMember]
        private IEnumerable<XMLTypeMetadata> m_ImplementedInterfaces;
        [DataMember]
        private IEnumerable<XMLTypeMetadata> m_NestedTypes;
        [DataMember]
        private IEnumerable<XMLPropertyMetadata> m_Properties;
        [DataMember]
        private IEnumerable<XMLMethodMetadata> m_Methods;
        [DataMember]
        private IEnumerable<XMLMethodMetadata> m_Constructors;

        
        public string TypeName { get => m_typeName; set => m_typeName = value; }
        public XMLTypeMetadata BaseType { get => m_BaseType; set => m_BaseType = value; }
        public IEnumerable<XMLTypeMetadata> GenericArguments { get => m_GenericArguments; set => m_GenericArguments = value; }
        public bool IsGenericType { get => m_isGenericType; set => m_isGenericType = value; }
        public IEnumerable<XMLTypeMetadata> ImplementedInterfaces { get => m_ImplementedInterfaces; set => m_ImplementedInterfaces = value; }
        public IEnumerable<XMLTypeMetadata> NestedTypes { get => m_NestedTypes; set => m_NestedTypes = value; }
        public IEnumerable<XMLPropertyMetadata> Properties { get => m_Properties; set => m_Properties = value; }
        public IEnumerable<XMLMethodMetadata> Methods { get => m_Methods; set => m_Methods = value; }
        public IEnumerable<XMLMethodMetadata> Constructors { get => m_Constructors; set => m_Constructors = value; }
    }
}