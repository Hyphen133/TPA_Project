using DataTransferGraph.Model;
using Logic.Model;
using System.Collections.Generic;
using System.Linq;

namespace Logic.DTGMapper
{
    public class MethodMapper
    {
        public static DTGMethodMetadata MapToDTGModel(MethodMetadata methodMetadata)
        {
            DTGMethodMetadata methodModel = new DTGMethodMetadata
            {
                Name = methodMetadata.Name,
                GenericArguments = TypeMapper.EmitGenericArgumentsDTG(methodMetadata.GenericArguments),
                ReturnType = EmitReturnTypeDTG(methodMetadata),
                Parameters = EmitParametersDTG(methodMetadata.Parameters),
            };
            return methodModel;
        }

        internal static IEnumerable<DTGMethodMetadata> EmitMethodsDTG(IEnumerable<MethodMetadata> methods)
        {
            return from MethodMetadata _currentMethod in methods
                   select MapToDTGModel(_currentMethod);
        }

        private static IEnumerable<DTGParameterMetadata> EmitParametersDTG(IEnumerable<ParameterMetadata> parms)
        {
            return from parm in parms
                   select ParameterMapper.MapToDTGModel(parm);
        }
        private static DTGTypeMetadata EmitReturnTypeDTG(MethodMetadata method)
        {
            MethodMetadata methodInfo = method as MethodMetadata;
            if (methodInfo == null)
                return null;
            return TypeMapper.EmitReferenceDTG(methodInfo.ReturnType);
        }

        public static MethodMetadata MapToModel(DTGMethodMetadata methodMetadata)
        {
            MethodMetadata methodModel = new MethodMetadata
            {
                Name = methodMetadata.Name,
                GenericArguments = TypeMapper.EmitGenericArgumentsModel(methodMetadata.GenericArguments),
                ReturnType = EmitReturnTypeModel(methodMetadata),
                Parameters = EmitParametersModel(methodMetadata.Parameters),
            };
            return methodModel;
        }

        internal static IEnumerable<MethodMetadata> EmitMethodsModel(IEnumerable<DTGMethodMetadata> methods)
        {
            if (methods == null) return null;
            return from DTGMethodMetadata _currentMethod in methods
                   select MapToModel(_currentMethod);
        }

        private static IEnumerable<ParameterMetadata> EmitParametersModel(IEnumerable<DTGParameterMetadata> parms)
        {
            return from parm in parms
                   select ParameterMapper.MapToModel(parm);
        }
        private static TypeMetadata EmitReturnTypeModel(DTGMethodMetadata method)
        {
            DTGMethodMetadata methodInfo = method as DTGMethodMetadata;
            if (methodInfo == null)
                return null;
            return TypeMapper.EmitReferenceModel(methodInfo.ReturnType);
        }
    }
}
