using System.Runtime.Serialization;

namespace DataSerializer.Model
{
    [DataContract(IsReference = true)]
    public class XMLParameterMetadata
    {
        [DataMember]
        private string m_Name;
        [DataMember]
        private XMLTypeMetadata m_TypeMetadata;

        public string Name { get => m_Name; set => m_Name = value; }
        public XMLTypeMetadata TypeMetadata { get => m_TypeMetadata; set => m_TypeMetadata = value; }

    }
}
