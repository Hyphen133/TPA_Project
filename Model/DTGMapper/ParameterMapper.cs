using DataTransferGraph.Model;
using Logic.Model;

namespace Logic.DTGMapper
{
    public class ParameterMapper
    {
        public ParameterMetadata MapFromDTGModel(DTGParameterModel model)
        {
            ParameterMetadata parameterMetadata = new ParameterMetadata();
            parameterMetadata.Name = model.Name;
            if (model.Type != null)
                parameterMetadata.TypeMetadata = TypeMapper.EmitType((DTGTypeModel)model.Type);
            return parameterMetadata;
        }

        public DTGParameterModel MapToDTGModel(ParameterMetadata model)
        {
            DTGParameterModel parameterModel = new DTGParameterModel();
            parameterModel.Name = model.Name;
            if (model.TypeMetadata != null)
                parameterModel.Type = TypeMapper.EmitXMLType(model.TypeMetadata);
            return parameterModel;
        }
    }
}
