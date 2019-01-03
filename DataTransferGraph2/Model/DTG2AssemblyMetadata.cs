using System.Collections.Generic;

namespace DataTransferGraph2.Model
{
    public class DTG2AssemblyMetadata
    {
        private string m_Name;
        private IEnumerable<DTG2NamespaceMetadata> m_Namespaces;

        public IEnumerable<DTG2NamespaceMetadata> Namespaces { get => m_Namespaces; set => m_Namespaces = value; }
        public string Name { get => m_Name; set => m_Name = value; }
    }
}