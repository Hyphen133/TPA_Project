using DataSerializer.Model;
using DataTransferGraph.Model;
using System.Linq;

namespace DataSerializer.SerializationMapper
{
    public class SerializationNamespaceMapper
    {
        public XMLNamespaceMetadata MapToUpper(DTGNamespaceModel model)
        {
            XMLNamespaceMetadata namespaceMetadata = new XMLNamespaceMetadata
            {
                NamespaceName = model.NamespaceName
            };
            if (model.Types != null)
                namespaceMetadata.Types = model.Types.Select(n => SerializationTypeMapper.EmitType(n)).ToList();
            return namespaceMetadata;
        }

        public DTGNamespaceModel MapToLower(XMLNamespaceMetadata model)
        {
            DTGNamespaceModel namespaceModel = new DTGNamespaceModel
            {
                NamespaceName = model.NamespaceName
            };
            if (model.Types != null)
                namespaceModel.Types = model.Types.Select(t => new SerializationTypeMapper().MapToLower(t)).ToList();
            return namespaceModel;
        }
    }
}
