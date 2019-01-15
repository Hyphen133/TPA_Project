using System.Collections.Generic;
using System.Linq;

namespace DataTransferGraph.Model
{
    public class DTGNamespaceMetadata
    {
        private string m_NamespaceName;
        private IEnumerable<DTGTypeMetadata> m_Types;

        public string NamespaceName { get => m_NamespaceName; set => m_NamespaceName = value; }
        public IEnumerable<DTGTypeMetadata> Types { get => m_Types; set => m_Types = value; }
    }
}