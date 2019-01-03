using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace DataSerializer.Model
{
    [DataContract(IsReference = true)]
    public class XMLMethodMetadata
    {
        [DataMember]
        private string m_Name;
        [DataMember]
        private List<XMLTypeMetadata> l_GenericArguments;
        private IEnumerable<XMLTypeMetadata> m_GenericArguments;
        [DataMember]
        private XMLTypeMetadata m_ReturnType;
        [DataMember]
        private bool m_Extension;
        [DataMember]
        private List<XMLParameterMetadata> l_Parameters;
        private IEnumerable<XMLParameterMetadata> m_Parameters;

        public string Name { get => m_Name; set => m_Name = value; }
        public IEnumerable<XMLTypeMetadata> GenericArguments { get => m_GenericArguments; set => m_GenericArguments = value; }
        public List<XMLTypeMetadata> GenericArgumentsL { get => l_GenericArguments; set => l_GenericArguments = value; }
        public XMLTypeMetadata ReturnType { get => m_ReturnType; set => m_ReturnType = value; }
        public IEnumerable<XMLParameterMetadata> Parameters { get => m_Parameters; set => m_Parameters = value; }
        public List<XMLParameterMetadata> ParametersL { get => l_Parameters; set => l_Parameters = value; }

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
