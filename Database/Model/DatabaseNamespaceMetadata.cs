using System.Collections.Generic;
using System.Linq;

namespace Database.Model
{
    public class DatabaseNamespaceMetadata
    {
        private int m_NamespaceID;
        private string m_NamespaceName;
        private List<DatabaseTypeMetadata> l_Types;
        private IEnumerable<DatabaseTypeMetadata> m_Types;

        public int NamespaceID { get => m_NamespaceID; set => m_NamespaceID = value; }
        public string NamespaceName { get => m_NamespaceName; set => m_NamespaceName = value; }
        public IEnumerable<DatabaseTypeMetadata> Types { get => m_Types; set => m_Types = value; }
        public List<DatabaseTypeMetadata> TypesL { get => l_Types; set => l_Types = value; }

        public void SetValues()
        {
            l_Types = m_Types.ToList();
            foreach (var i in l_Types)
            {
                i.SetValue();
            }
        }
    }
}
