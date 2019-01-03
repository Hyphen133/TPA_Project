using System.Collections.Generic;
using System.Linq;

namespace DataTransferGraph2.Model
{
    public class DTG2NamespaceMetadata
    {
        private string m_NamespaceName;
        private IEnumerable<DTG2TypeMetadata> m_Types;

        public string NamespaceName { get => m_NamespaceName; set => m_NamespaceName = value; }
        public IEnumerable<DTG2TypeMetadata> Types { get => m_Types; set => m_Types = value; }
    }
}