using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace DataSerializer.Model
{
    [DataContract(IsReference = true)]
    public class XMLAssemblyMetadata
    {
        [DataMember]
        private string m_Name;
        [DataMember]
        private List<XMLNamespaceMetadata> l_Namespaces;
        private IEnumerable<XMLNamespaceMetadata> m_Namespaces;

        public IEnumerable<XMLNamespaceMetadata> Namespaces { get => m_Namespaces; set => m_Namespaces = value; }
        public List<XMLNamespaceMetadata> NamespacesL { get => l_Namespaces; set => l_Namespaces = value; }
        public string Name { get => m_Name; set => m_Name = value; }

        public void SetValues()
        {
            l_Namespaces = m_Namespaces.ToList();
            foreach(var n in l_Namespaces)
            {
                n.SetValues();
            }
        }
    }
}
