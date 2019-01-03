using DataTransferGraph2.Model;
using Logic.Model;

namespace Logic.DTGMapper
{
    public class ParameterMapper
    {
        public static DTG2ParameterMetadata MapToDTGModel(ParameterMetadata parameterMetadata)
        {
            DTG2ParameterMetadata parameterModel = new DTG2ParameterMetadata
            {
                Name = parameterMetadata.Name,
                TypeMetadata = TypeMapper.EmitReferenceDTG(parameterMetadata.TypeMetadata),
            };
            return parameterModel;
        }

        public static ParameterMetadata MapToModel(DTG2ParameterMetadata parameterMetadata)
        {
            ParameterMetadata parameterModel = new ParameterMetadata
            {
                Name = parameterMetadata.Name,
                TypeMetadata = TypeMapper.EmitReferenceModel(parameterMetadata.TypeMetadata),
            };
            return parameterModel;
        }
    }
}
