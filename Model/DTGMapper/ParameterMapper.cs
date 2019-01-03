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
                TypeMetadata = TypeMapper.EmitReference(parameterMetadata.TypeMetadata),
            };
            return parameterModel;
        }
    }
}
