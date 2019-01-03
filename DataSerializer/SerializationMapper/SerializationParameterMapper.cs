using DataSerializer.Model;
using DataTransferGraph.Model;

namespace DataSerializer.SerializationMapper
{
    public class SerializationParameterMapper
    {
        public XMLParameterMetadata MapToUpper(DTGParameterModel model)
        {
            XMLParameterMetadata parameterMetadata = new XMLParameterMetadata
            {
                Name = model.Name
            };
            if (model.Type != null)
                parameterMetadata.Type = SerializationTypeMapper.EmitType(model.Type);
            return parameterMetadata;
        }

        public DTGParameterModel MapToLower(XMLParameterMetadata model)
        {
            DTGParameterModel parameterModel = new DTGParameterModel
            {
                Name = model.Name
            };
            if (model.Type != null)
                parameterModel.Type = SerializationTypeMapper.EmitXMLType(model.Type);
            return parameterModel;
        }
    }
}
