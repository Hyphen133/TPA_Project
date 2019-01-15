using System.Collections.Generic;

namespace DataTransferGraph.Model
{
    public class DTGAssemblyMetadata
    {
        private string m_Name;
        private IEnumerable<DTGNamespaceMetadata> m_Namespaces;

        public IEnumerable<DTGNamespaceMetadata> Namespaces { get => m_Namespaces; set => m_Namespaces = value; }
        public string Name { get => m_Name; set => m_Name = value; }
    }
}