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
                TypeMetadata = SerializationTypeMapper.EmitReferenceXML(parameterMetadata.TypeMetadata),
            };
            return parameterModel;
        }

        public static DTG2ParameterMetadata MapToDTG(XMLParameterMetadata parameterMetadata)
        {
            DTG2ParameterMetadata parameterModel = new DTG2ParameterMetadata
            {
                Name = parameterMetadata.Name,
                TypeMetadata = SerializationTypeMapper.EmitReferenceDTG(parameterMetadata.TypeMetadata),
            };
            return parameterModel;
        }
    }
}
