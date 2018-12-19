using DataSerializer.SerializationModel;
using Model.Model;
using System.ComponentModel.Composition;
using System.Linq;

namespace DataSerializer.SerializationMapper
{
    [Export]
    class AssemblyMapper : IModelMapper
    {
        public IAssemblyModel MapToLower(AssemblyMetadata model)
        {
            SerializableAssemblyModel assemblyModel = new SerializableAssemblyModel();
            assemblyModel.Name = model.Name;
            if (model.Namespaces != null)
                assemblyModel.NamespaceModels = model.Namespaces.Select(n => new NamespaceMapper().MapToLower(n)).ToList();
            return assemblyModel;
        }

        public AssemblyMetadata MapToUpper(IAssemblyModel model)
        {
            AssemblyMetadata assemblyMetadata = new AssemblyMetadata();
            assemblyMetadata.Name = model.Name;
            if (((SerializableAssemblyModel)model).NamespaceModels != null)
                assemblyMetadata.Namespaces = ((SerializableAssemblyModel)model).NamespaceModels.Select(n => new NamespaceMapper().MapToUpper(n)).ToList();
            return assemblyMetadata;
        }
    }
}
