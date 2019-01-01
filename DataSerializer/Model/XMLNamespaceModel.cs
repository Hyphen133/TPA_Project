using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataSerializer.Model
{
    [DataContract(IsReference = true)]
    public class XMLNamespaceModel
    {
        [DataMember]
        public string NamespaceName { get; set; }

        [DataMember]
        public List<XMLTypeModel> Types { get; set; }
    }
}
