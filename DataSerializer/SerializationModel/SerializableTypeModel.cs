using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataSerializer.SerializationModel
{
    [DataContract(IsReference = true)]
    public class SerializableTypeModel
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string AssemblyName { get; set; }

        [DataMember]
        public bool IsExternal { get; set; }

        [DataMember]
        public bool IsGeneric { get; set; }

        [DataMember]
        public SerializableTypeModel BaseType { get; set; }

        [DataMember]
        public List<SerializableTypeModel> GenericArguments { get; set; }

        //[DataMember]
        //public TypeModifiers Modifiers { get; set; }

        //[DataMember]
        //public TypeEnum Type { get; set; }

        [DataMember]
        public List<SerializableTypeModel> ImplementedInterfaces { get; set; }

        [DataMember]
        public List<SerializableTypeModel> NestedTypes { get; set; }

        [DataMember]
        public List<SerializablePropertyModel> Properties { get; set; }

        [DataMember]
        public SerializableTypeModel DeclaringType { get; set; }

        [DataMember]
        public List<SerializableMethodModel> Methods { get; set; }

        [DataMember]
        public List<SerializableMethodModel> Constructors { get; set; }

        [DataMember]
        public List<SerializableParameterModel> Fields { get; set; }
    }
}
