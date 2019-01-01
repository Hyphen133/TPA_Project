using System.Collections.Generic;

namespace DataTransferGraph.Model
{
    public class DTGMethodModel
    {
        public string Name { get; set; }
        public List<DTGTypeModel> GenericArguments { get; set; }

        //public MethodModifiers Modifiers { get; set; }
        
        public DTGTypeModel ReturnType { get; set; }

        public bool Extension { get; set; }
        
        public List<DTGParameterModel> Parameters { get; set; }
    }
}
