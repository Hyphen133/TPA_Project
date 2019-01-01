using System.Runtime.Serialization;

namespace DataSerializer.Model
{
    [DataContract(IsReference = true)]
    public class XMLPropertyModel
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public XMLTypeModel Type { get; set; }
    }
}
