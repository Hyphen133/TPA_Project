using DataSerializer.SerializationModel;
using Model.Model;
using System.Linq;

namespace DataSerializer.SerializationMapper
{
    public class NamespaceMapper
    {
        public NamespaceMetadata MapToUpper(SerializableNamespaceModel model)
        {
            NamespaceMetadata namespaceMetadata = new NamespaceMetadata();
            namespaceMetadata.NamespaceName = model.Name;
            if (model.Types != null)
                namespaceMetadata.Types = model.Types.Select(n => TypeMapper.EmitType((SerializableTypeModel)n)).ToList();
            return namespaceMetadata;
        }

        public SerializableNamespaceModel MapToLower(NamespaceMetadata model)
        {
            SerializableNamespaceModel namespaceModel = new SerializableNamespaceModel();
            namespaceModel.Name = model.NamespaceName;
            if (model.Types != null)
                namespaceModel.Types = model.Types.Select(t => new TypeMapper().MapToLower(t)).ToList();
            return namespaceModel;
        }
    }
}
