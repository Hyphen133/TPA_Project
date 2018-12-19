using Data.SerializationModel;
using Model.Model;

namespace DataSerializer.SerializationMapper
{
    public class PropertyMapper
    {
        public PropertyMetadata MapToUpper(SerializablePropertyModel model)
    {
        PropertyMetadata propertyMetadata = new PropertyMetadata();
        propertyMetadata.Name = model.Name;
        if (model.Type != null)
            propertyMetadata.TypeMetadata = TypeMapper.EmitType((SerializableTypeModel)model.Type);
        return propertyMetadata;
    }

    public SerializablePropertyModel MapToLower(PropertyMetadata model)
    {
        SerializablePropertyModel propertyModel = new SerializablePropertyModel();
        propertyModel.Name = model.Name;
        if (model.TypeMetadata != null)
            propertyModel.Type = TypeMapper.EmitXMLType(model.TypeMetadata);
        return propertyModel;
    }
    }
}
