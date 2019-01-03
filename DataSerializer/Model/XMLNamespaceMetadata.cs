using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataSerializer.Model
{
    [DataContract(IsReference = true)]
    public class XMLNamespaceMetadata
    {
        [DataMember]
        private string m_NamespaceName;
        [DataMember]
        private IEnumerable<XMLTypeMetadata> m_Types;

        public string NamespaceName { get => m_NamespaceName; set => m_NamespaceName = value; }
        public IEnumerable<XMLTypeMetadata> Types { get => m_Types; set => m_Types = value; }
    }
}