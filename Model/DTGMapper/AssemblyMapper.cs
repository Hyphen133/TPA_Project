using DataTransferGraph.Model;
using Logic.Model;
using System.ComponentModel.Composition;
using System.Linq;

namespace Logic.DTGMapper
{
    [Export]
    public class AssemblyMapper
    {
        public DTGAssemblyModel MapToDTGModel(AssemblyMetadata model)
        {
            DTGAssemblyModel assemblyModel = new DTGAssemblyModel
            {
                Name = model.Name
            };
            if (model.Namespaces != null)
                assemblyModel.Namespaces = model.Namespaces.Select(n => new NamespaceMapper().MapToDTGModel(n)).ToList();
            return assemblyModel;
        }

        public AssemblyMetadata MapFromDTGModel(DTGAssemblyModel model)
        {
            AssemblyMetadata assemblyMetadata = new AssemblyMetadata
            {
                Name = model.Name
            };
            if (((DTGAssemblyModel)model).Namespaces != null)
                assemblyMetadata.Namespaces = ((DTGAssemblyModel)model).Namespaces.Select(n => new NamespaceMapper().MapFromDTGModel(n)).ToList();
            return assemblyMetadata;
        }
    }
}
