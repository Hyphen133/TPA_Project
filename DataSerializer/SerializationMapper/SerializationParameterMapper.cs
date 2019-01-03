using DataSerializer.Model;
using DataTransferGraph2.Model;

namespace DataSerializer.SerializationMapper
{
    public class SerializationParameterMapper
    {
        public static XMLParameterMetadata MapToXML(DTG2ParameterMetadata parameterMetadata)
        {
            XMLParameterMetadata parameterModel = new XMLParameterMetadata
            {
                Name = parameterMetadata.Name,
                TypeMetadata = SerializationTypeMapper.EmitReference(parameterMetadata.TypeMetadata),
            };
            return parameterModel;
        }
    }
}
