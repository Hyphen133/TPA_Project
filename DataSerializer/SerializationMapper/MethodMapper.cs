using DataSerializer.SerializationModel;
using Model.Model;
using System.Linq;

namespace DataSerializer.SerializationMapper
{
    public class MethodMapper
    {

        public MethodMetadata MapToUpper(SerializableMethodModel model)
        {
            MethodMetadata methodMetadata = new MethodMetadata();
            methodMetadata.Name = model.Name;
            methodMetadata.Extension = model.Extension;
            if (model.GenericArguments != null)
                methodMetadata.GenericArguments = model.GenericArguments.Select(g => TypeMapper.EmitType((SerializableTypeModel)g)).ToList();
            //methodMetadata.Modifiers = model.Modifiers;
            if (model.Parameters != null)
                methodMetadata.Parameters = model.Parameters.Select(p => new ParameterMapper().MapToUpper((SerializableParameterModel)p)).ToList();
            if (model.ReturnType != null)
                methodMetadata.ReturnType = TypeMapper.EmitType((SerializableTypeModel)model.ReturnType);
            return methodMetadata;
        }

        public SerializableMethodModel MapToLower(MethodMetadata model)
        {
            SerializableMethodModel methodModel = new SerializableMethodModel();
            methodModel.Name = model.Name;
            methodModel.Extension = model.Extension;
            if (model.GenericArguments != null)
                methodModel.GenericArguments = model.GenericArguments.Select(t => TypeMapper.EmitXMLType(t)).ToList();
            //methodModel.Modifiers = model.Modifiers;
            if (model.Parameters != null)
                methodModel.Parameters = model.Parameters.Select(p => new ParameterMapper().MapToLower(p)).ToList();
            if (model.ReturnType != null)
                methodModel.ReturnType = TypeMapper.EmitXMLType(model.ReturnType);
            return methodModel;
        }
    }
}
