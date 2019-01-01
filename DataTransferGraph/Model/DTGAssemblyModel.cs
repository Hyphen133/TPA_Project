using System.Collections.Generic;

namespace DataTransferGraph.Model
{
    public class DTGAssemblyModel
    {
        public string Name { get; set; }
        public List<DTGNamespaceModel> Namespaces { get; set; }
    }
}
