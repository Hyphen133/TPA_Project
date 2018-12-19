using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Data.SerializationModel
{
    [DataContract(IsReference = true)]
    public class SerializableMethodModel
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<SerializableTypeModel> GenericArguments { get; set; }

        //[DataMember]
        //public MethodModifiers Modifiers { get; set; }

        [DataMember]
        public SerializableTypeModel ReturnType { get; set; }

        [DataMember]
        public bool Extension { get; set; }

        [DataMember]
        public List<SerializableParameterModel> Parameters { get; set; }
    }
}
