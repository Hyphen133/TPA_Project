using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Database.Model
{
    public class DatabaseAssemblyMetadata
    {
        private int m_AssemblyID;
        private string m_Name;
        private List<DatabaseNamespaceMetadata> l_Namespaces;
        private IEnumerable<DatabaseNamespaceMetadata> m_Namespaces;

        public int AssemblyID { get => m_AssemblyID; set => m_AssemblyID = value; }
        public IEnumerable<DatabaseNamespaceMetadata> Namespaces { get => m_Namespaces; set => m_Namespaces = value; }
        public List<DatabaseNamespaceMetadata> NamespacesL { get => l_Namespaces; set => l_Namespaces = value; }
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
