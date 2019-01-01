using System.Collections.Generic;

namespace DataTransferGraph.Model
{
    public class DTGTypeModel
    {
        public string Name { get; set; }
        
        public string AssemblyName { get; set; }
        
        public bool IsExternal { get; set; }
        
        public bool IsGeneric { get; set; }
        
        public DTGTypeModel BaseType { get; set; }
        
        public List<DTGTypeModel> GenericArguments { get; set; }

        //[DataMember]
        //public TypeModifiers Modifiers { get; set; }

        //[DataMember]
        //public TypeEnum Type { get; set; }
        
        public List<DTGTypeModel> ImplementedInterfaces { get; set; }
        
        public List<DTGTypeModel> NestedTypes { get; set; }
        
        public List<DTGPropertyModel> Properties { get; set; }
        
        public DTGTypeModel DeclaringType { get; set; }
        
        public List<DTGMethodModel> Methods { get; set; }
        
        public List<DTGMethodModel> Constructors { get; set; }
        
        public List<DTGParameterModel> Fields { get; set; }
    }
}
