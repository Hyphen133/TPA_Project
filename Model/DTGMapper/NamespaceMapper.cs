using DataTransferGraph.Model;
using Logic.Model;
using System.Collections.Generic;
using System.Linq;

namespace Logic.DTGMapper
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
            {
                List<DTGTypeModel> types = new List<DTGTypeModel>();
                foreach (TypeMetadata type in model.Types)
                {
                    types.Add(new TypeMapper().MapToDTGModel(type));
                }
                namespaceModel.Types = types;
            }
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
