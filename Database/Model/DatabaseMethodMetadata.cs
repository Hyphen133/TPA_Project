using System.Collections.Generic;
using System.Linq;

namespace Database.Model
{
    public class DatabaseMethodMetadata
    {
        private int m_MethodID;
        private string m_Name;
        private List<DatabaseTypeMetadata> l_GenericArguments;
        private IEnumerable<DatabaseTypeMetadata> m_GenericArguments;
        private DatabaseTypeMetadata m_ReturnType;
        private bool m_Extension;
        private List<DatabaseParameterMetadata> l_Parameters;
        private IEnumerable<DatabaseParameterMetadata> m_Parameters;

        public int MethodID { get => m_MethodID; set => m_MethodID = value; }
        public string Name { get => m_Name; set => m_Name = value; }
        public IEnumerable<DatabaseTypeMetadata> GenericArguments { get => m_GenericArguments; set => m_GenericArguments = value; }
        public List<DatabaseTypeMetadata> GenericArgumentsL { get => l_GenericArguments; set => l_GenericArguments = value; }
        public DatabaseTypeMetadata ReturnType { get => m_ReturnType; set => m_ReturnType = value; }
        public IEnumerable<DatabaseParameterMetadata> Parameters { get => m_Parameters; set => m_Parameters = value; }
        public List<DatabaseParameterMetadata> ParametersL { get => l_Parameters; set => l_Parameters = value; }

        public void SetValue()
        {
            if (m_GenericArguments == null)
            {
                l_GenericArguments = null;
            }
            else
            {
                l_GenericArguments = m_GenericArguments.ToList();
                foreach (var i in l_GenericArguments)
                {
                    i.SetValue();
                }
            }

            l_Parameters = m_Parameters.ToList();
        }
    }
}
