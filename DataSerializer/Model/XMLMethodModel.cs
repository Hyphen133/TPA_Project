using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataSerializer.Model
{
    [DataContract(IsReference = true)]
    public class XMLMethodModel
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<XMLTypeModel> GenericArguments { get; set; }

        //public MethodModifiers Modifiers { get; set; }

        [DataMember]
        public XMLTypeModel ReturnType { get; set; }

        [DataMember]
        public bool Extension { get; set; }

        [DataMember]
        public List<XMLParameterModel> Parameters { get; set; }
    }
}
