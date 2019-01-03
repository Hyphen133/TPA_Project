using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataSerializer.Model
{
    [DataContract(IsReference = true)]
    public class XMLMethodMetadata
    {
        [DataMember]
        private string m_Name;
        [DataMember]
        private IEnumerable<XMLTypeMetadata> m_GenericArguments;
        [DataMember]
        private XMLTypeMetadata m_ReturnType;
        [DataMember]
        private bool m_Extension;
        [DataMember]
        private IEnumerable<XMLParameterMetadata> m_Parameters;

        public string Name { get => m_Name; set => m_Name = value; }
        public IEnumerable<XMLTypeMetadata> GenericArguments { get => m_GenericArguments; set => m_GenericArguments = value; }
        public XMLTypeMetadata ReturnType { get => m_ReturnType; set => m_ReturnType = value; }
        public IEnumerable<XMLParameterMetadata> Parameters { get => m_Parameters; set => m_Parameters = value; }
    }
}
