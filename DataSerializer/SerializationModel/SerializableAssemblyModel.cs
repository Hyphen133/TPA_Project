using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataSerializer.SerializationModel
{
    [DataContract]
    public class SerializableAssemblyModel : IAssemblyModel
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<SerializableNamespaceModel> NamespaceModels { get; set; }
    }
}
