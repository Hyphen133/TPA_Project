using DataTransferGraph2.Model;
using Logic.Model;
using System.Collections.Generic;
using System.Linq;

namespace Logic.DTGMapper
{
    public class MethodMapper
    {
        public static DTG2MethodMetadata MapToDTGModel(MethodMetadata methodMetadata)
        {
            DTG2MethodMetadata methodModel = new DTG2MethodMetadata
            {
                Name = methodMetadata.Name,
                GenericArguments = TypeMapper.EmitGenericArgumentsDTG(methodMetadata.GenericArguments),
                ReturnType = EmitReturnTypeDTG(methodMetadata),
                Parameters = EmitParametersDTG(methodMetadata.Parameters),
            };
            return methodModel;
        }

        internal static IEnumerable<DTG2MethodMetadata> EmitMethodsDTG(IEnumerable<MethodMetadata> methods)
        {
            return from MethodMetadata _currentMethod in methods
                   select MapToDTGModel(_currentMethod);
        }

        private static IEnumerable<DTG2ParameterMetadata> EmitParametersDTG(IEnumerable<ParameterMetadata> parms)
        {
            return from parm in parms
                   select ParameterMapper.MapToDTGModel(parm);
        }
        private static DTG2TypeMetadata EmitReturnTypeDTG(MethodMetadata method)
        {
            MethodMetadata methodInfo = method as MethodMetadata;
            if (methodInfo == null)
                return null;
            return TypeMapper.EmitReferenceDTG(methodInfo.ReturnType);
        }

        public static MethodMetadata MapToModel(DTG2MethodMetadata methodMetadata)
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

        internal static IEnumerable<MethodMetadata> EmitMethodsModel(IEnumerable<DTG2MethodMetadata> methods)
        {
            if (methods == null) return null;
            return from DTG2MethodMetadata _currentMethod in methods
                   select MapToModel(_currentMethod);
        }

        private static IEnumerable<ParameterMetadata> EmitParametersModel(IEnumerable<DTG2ParameterMetadata> parms)
        {
            return from parm in parms
                   select ParameterMapper.MapToModel(parm);
        }
        private static TypeMetadata EmitReturnTypeModel(DTG2MethodMetadata method)
        {
            DTG2MethodMetadata methodInfo = method as DTG2MethodMetadata;
            if (methodInfo == null)
                return null;
            return TypeMapper.EmitReferenceModel(methodInfo.ReturnType);
        }
    }
}
