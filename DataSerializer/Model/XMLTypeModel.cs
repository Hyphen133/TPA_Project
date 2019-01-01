using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataSerializer.Model
{
    [DataContract(IsReference = true)]
    public class XMLTypeModel
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
        public XMLTypeModel BaseType { get; set; }

        [DataMember]
        public List<XMLTypeModel> GenericArguments { get; set; }

        //[DataMember]
        //public TypeModifiers Modifiers { get; set; }

        //[DataMember]
        //public TypeEnum Type { get; set; }

        [DataMember]
        public List<XMLTypeModel> ImplementedInterfaces { get; set; }

        [DataMember]
        public List<XMLTypeModel> NestedTypes { get; set; }

        [DataMember]
        public List<XMLPropertyModel> Properties { get; set; }

        [DataMember]
        public XMLTypeModel DeclaringType { get; set; }

        [DataMember]
        public List<XMLMethodModel> Methods { get; set; }

        [DataMember]
        public List<XMLMethodModel> Constructors { get; set; }

        [DataMember]
        public List<XMLParameterModel> Fields { get; set; }
    }
}
