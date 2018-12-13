using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Data
{
    [DataContract(IsReference = true)]
    public class NamespaceMetadata
    {
        [DataMember]
        private string m_NamespaceName;
        [DataMember]
        private IEnumerable<TypeMetadata> m_Types;

        public string NamespaceName { get => m_NamespaceName; set => m_NamespaceName = value; }
        public IEnumerable<TypeMetadata> Types { get => m_Types; set => m_Types = value; }
    }
}