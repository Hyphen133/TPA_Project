using Data.SerializationModel;
using Model.Model;

namespace DataSerializer.SerializationMapper
{
    public class ParameterMapper
    {
        public ParameterMetadata MapToUpper(SerializableParameterModel model)
        {
            ParameterMetadata parameterMetadata = new ParameterMetadata();
            parameterMetadata.Name = model.Name;
            if (model.Type != null)
                parameterMetadata.TypeMetadata = TypeMapper.EmitType((SerializableTypeModel)model.Type);
            return parameterMetadata;
        }

        public SerializableParameterModel MapToLower(ParameterMetadata model)
        {
            SerializableParameterModel parameterModel = new SerializableParameterModel();
            parameterModel.Name = model.Name;
            if (model.TypeMetadata != null)
                parameterModel.Type = TypeMapper.EmitXMLType(model.TypeMetadata);
            return parameterModel;
        }
    }
}
