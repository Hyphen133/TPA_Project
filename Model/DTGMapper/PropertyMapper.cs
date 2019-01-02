using DataTransferGraph.Model;
using Logic.Model;

namespace Logic.DTGMapper
{
    public class PropertyMapper
    {
        public DTGPropertyModel MapToDTGModel(PropertyMetadata model)
        {
            DTGPropertyModel propertyModel = new DTGPropertyModel();
            propertyModel.Name = model.Name;
            if (model.TypeMetadata != null)
                propertyModel.Type = TypeMapper.EmitXMLType(model.TypeMetadata);
            return propertyModel;
        }

        public PropertyMetadata MapFromDTGModel(DTGPropertyModel model)
        {
            PropertyMetadata propertyMetadata = new PropertyMetadata
            {
                Name = model.Name
            };
            if (model.Type != null)
                propertyMetadata.TypeMetadata = TypeMapper.EmitType(model.Type);
            return propertyMetadata;
        }
    }
}
