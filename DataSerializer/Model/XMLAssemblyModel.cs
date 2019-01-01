using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataSerializer.Model
{
    [DataContract(IsReference = true)]
    public class XMLAssemblyModel
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<XMLNamespaceModel> Namespaces { get; set; }
    }
}
