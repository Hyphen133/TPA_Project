using System.Collections.Generic;

namespace DataTransferGraph.Model
{
    public class DTGNamespaceModel
    {
        public string NamespaceName { get; set; }
        
        public List<DTGTypeModel> Types { get; set; }
    }
}
