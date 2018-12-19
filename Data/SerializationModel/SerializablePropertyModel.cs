using System.Runtime.Serialization;

namespace Data.SerializationModel
{
    [DataContract(IsReference = true)]
    public class SerializablePropertyModel
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public SerializableTypeModel Type { get; set; }
    }
}
