using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace DataSerializer.Model
{
    [DataContract(IsReference = true)]
    public class XMLNamespaceMetadata
    {
        [DataMember]
        private string m_NamespaceName;
        [DataMember]
        private List<XMLTypeMetadata> l_Types;
        private IEnumerable<XMLTypeMetadata> m_Types;

        public string NamespaceName { get => m_NamespaceName; set => m_NamespaceName = value; }
        public IEnumerable<XMLTypeMetadata> Types { get => m_Types; set => m_Types = value; }
        public List<XMLTypeMetadata> TypesL { get => l_Types; set => l_Types = value; }

        public void SetValues()
        {
            l_Types = m_Types.ToList();
            foreach(var i in l_Types)
            {
                i.SetValue();
            }
        }
    }
}
