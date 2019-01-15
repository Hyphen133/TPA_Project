using DataTransferGraph.Model;
using Logic.Model;

namespace Logic.DTGMapper
{
    public class ParameterMapper
    {
        public static DTGParameterMetadata MapToDTGModel(ParameterMetadata parameterMetadata)
        {
            DTGParameterMetadata parameterModel = new DTGParameterMetadata
            {
                Name = parameterMetadata.Name,
                TypeMetadata = TypeMapper.EmitReferenceDTG(parameterMetadata.TypeMetadata),
            };
            return parameterModel;
        }

        public static ParameterMetadata MapToModel(DTGParameterMetadata parameterMetadata)
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
