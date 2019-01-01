using DataSerializer.Model;
using DataTransferGraph.Model;

namespace DataSerializer.SerializationMapper
{
    public class SerializationPropertyMapper
    {
        public XMLPropertyModel MapToUpper(DTGPropertyModel model)
        {
            XMLPropertyModel propertyMetadata = new XMLPropertyModel
            {
                Name = model.Name
            };
            if (model.Type != null)
                propertyMetadata.Type = SerializationTypeMapper.EmitType(model.Type);
            return propertyMetadata;
        }

        public DTGPropertyModel MapToLower(XMLPropertyModel model)
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
