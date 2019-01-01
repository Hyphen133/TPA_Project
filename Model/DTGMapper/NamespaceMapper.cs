using DataTransferGraph.Model;
using Model.Model;
using System.Linq;

namespace Model.DTGMapper
{
    public class NamespaceMapper
    {
        public DTGNamespaceModel MapToDTGModel(NamespaceMetadata model)
        {
            DTGNamespaceModel namespaceModel = new DTGNamespaceModel
            {
                NamespaceName = model.NamespaceName
            };
            if (model.Types != null)
                namespaceModel.Types = model.Types.Select(t => new TypeMapper().MapToDTGModel(t)).ToList();
            return namespaceModel;
        }

        public NamespaceMetadata MapFromDTGModel(DTGNamespaceModel model)
        {
            NamespaceMetadata namespaceMetadata = new NamespaceMetadata
            {
                NamespaceName = model.NamespaceName
            };
            if (model.Types != null)
                namespaceMetadata.Types = model.Types.Select(n => TypeMapper.EmitType((DTGTypeModel)n)).ToList();
            return namespaceMetadata;
        }

    }
}
