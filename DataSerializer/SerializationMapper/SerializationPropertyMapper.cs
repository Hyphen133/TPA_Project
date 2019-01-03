using DataSerializer.Model;
using DataTransferGraph.Model;

namespace DataSerializer.SerializationMapper
{
    public class SerializationPropertyMapper
    {
        public XMLPropertyMetadata MapToUpper(DTGPropertyModel model)
        {
            XMLPropertyMetadata propertyMetadata = new XMLPropertyMetadata
            {
                Name = model.Name
            };
            if (model.Type != null)
                propertyMetadata.Type = SerializationTypeMapper.EmitType(model.Type);
            return propertyMetadata;
        }

        public DTGPropertyModel MapToLower(XMLPropertyMetadata model)
        {
            DTGPropertyModel propertyModel = new DTGPropertyModel
            {
                Name = model.Name
            };
            if (model.Type != null)
                propertyModel.Type = SerializationTypeMapper.EmitXMLType(model.Type);
            return propertyModel;
        }
    }
}
