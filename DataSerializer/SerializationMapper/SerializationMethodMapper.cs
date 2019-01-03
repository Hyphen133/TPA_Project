using DataSerializer.Model;
using DataTransferGraph.Model;
using System.Linq;

namespace DataSerializer.SerializationMapper
{
    public class SerializationMethodMapper
    {
        public XMLMethodMetadata MapToUpper(DTGMethodModel model)
        {
            XMLMethodMetadata methodMetadata = new XMLMethodMetadata
            {
                Name = model.Name,
                Extension = model.Extension
            };
            if (model.GenericArguments != null)
                methodMetadata.GenericArguments = model.GenericArguments.Select(g => SerializationTypeMapper.EmitType(g)).ToList();
            //methodMetadata.Modifiers = model.Modifiers;
            if (model.Parameters != null)
                methodMetadata.Parameters = model.Parameters.Select(p => new SerializationParameterMapper().MapToUpper(p)).ToList();
            if (model.ReturnType != null)
                methodMetadata.ReturnType = SerializationTypeMapper.EmitType(model.ReturnType);
            return methodMetadata;
        }

        public DTGMethodModel MapToLower(XMLMethodMetadata model)
        {
            DTGMethodModel methodModel = new DTGMethodModel
            {
                Name = model.Name,
                Extension = model.Extension
            };
            if (model.GenericArguments != null)
                methodModel.GenericArguments = model.GenericArguments.Select(t => SerializationTypeMapper.EmitXMLType(t)).ToList();
            //methodModel.Modifiers = model.Modifiers;
            if (model.Parameters != null)
                methodModel.Parameters = model.Parameters.Select(p => new SerializationParameterMapper().MapToLower(p)).ToList();
            if (model.ReturnType != null)
                methodModel.ReturnType = SerializationTypeMapper.EmitXMLType(model.ReturnType);
            return methodModel;
        }
    }
}
