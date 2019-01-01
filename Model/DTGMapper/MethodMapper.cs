using DataTransferGraph.Model;
using Model.Model;
using System.Linq;

namespace Model.DTGMapper
{
    public class MethodMapper
    {
        public DTGMethodModel MapToDTGModel(MethodMetadata model)
        {
            DTGMethodModel methodModel = new DTGMethodModel
            {
                Name = model.Name,
                Extension = model.Extension
            };
            if (model.GenericArguments != null)
                methodModel.GenericArguments = model.GenericArguments.Select(t => TypeMapper.EmitXMLType(t)).ToList();
            //methodModel.Modifiers = model.Modifiers;
            if (model.Parameters != null)
                methodModel.Parameters = model.Parameters.Select(p => new ParameterMapper().MapToDTGModel(p)).ToList();
            if (model.ReturnType != null)
                methodModel.ReturnType = TypeMapper.EmitXMLType(model.ReturnType);
            return methodModel;
        }

        public MethodMetadata MapFromDTGModel(DTGMethodModel model)
        {
            MethodMetadata methodMetadata = new MethodMetadata
            {
                Name = model.Name,
                Extension = model.Extension
            };
            if (model.GenericArguments != null)
                methodMetadata.GenericArguments = model.GenericArguments.Select(g => TypeMapper.EmitType((DTGTypeModel)g)).ToList();
            //methodMetadata.Modifiers = model.Modifiers;
            if (model.Parameters != null)
                methodMetadata.Parameters = model.Parameters.Select(p => new ParameterMapper().MapFromDTGModel((DTGParameterModel)p)).ToList();
            if (model.ReturnType != null)
                methodMetadata.ReturnType = TypeMapper.EmitType((DTGTypeModel)model.ReturnType);
            return methodMetadata;
        }
    }
}
