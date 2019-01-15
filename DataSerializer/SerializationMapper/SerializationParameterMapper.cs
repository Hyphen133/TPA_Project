using DataSerializer.Model;
using DataTransferGraph.Model;

namespace DataSerializer.SerializationMapper
{
    public class SerializationParameterMapper
    {
        public static XMLParameterMetadata MapToXML(DTGParameterMetadata parameterMetadata)
        {
            XMLParameterMetadata parameterModel = new XMLParameterMetadata
            {
                Name = parameterMetadata.Name,
                TypeMetadata = SerializationTypeMapper.EmitReferenceXML(parameterMetadata.TypeMetadata),
            };
            return parameterModel;
        }

        public static DTGParameterMetadata MapToDTG(XMLParameterMetadata parameterMetadata)
        {
            DTGParameterMetadata parameterModel = new DTGParameterMetadata
            {
                Name = parameterMetadata.Name,
                TypeMetadata = SerializationTypeMapper.EmitReferenceDTG(parameterMetadata.TypeMetadata),
            };
            return parameterModel;
        }
    }
}
