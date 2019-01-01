using DataSerializer.Model;
using DataTransferGraph.Model;
using System.ComponentModel.Composition;
using System.Linq;

namespace DataSerializer.SerializationMapper
{
    [Export]
    class SerializationAssemblyMapper
    {
        public DTGAssemblyModel MapToLower(XMLAssemblyModel model)
        {
            DTGAssemblyModel assemblyModel = new DTGAssemblyModel
            {
                Name = model.Name
            };
            if (model.Namespaces != null)
                assemblyModel.Namespaces = model.Namespaces.Select(n => new SerializationNamespaceMapper().MapToLower(n)).ToList();
            return assemblyModel;
        }

        public XMLAssemblyModel MapToUpper(DTGAssemblyModel model)
        {
            XMLAssemblyModel assemblyMetadata = new XMLAssemblyModel
            {
                Name = model.Name
            };
            if (model.Namespaces != null)
                assemblyMetadata.Namespaces = model.Namespaces.Select(n => new SerializationNamespaceMapper().MapToUpper(n)).ToList();
            return assemblyMetadata;
        }
    }
}
