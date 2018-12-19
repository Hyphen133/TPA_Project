using System.Runtime.Serialization;

namespace DataSerializer.SerializationModel
{
    [DataContract(IsReference = true)]
    public class SerializableParameterModel
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public SerializableTypeModel Type { get; set; }

    }
}
