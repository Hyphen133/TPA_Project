using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Data.SerializationModel
{
    [DataContract(IsReference = true)]
    public class SerializableNamespaceModel
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<SerializableTypeModel> Types { get; set; }
    }
}
