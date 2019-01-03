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
                GenericArguments = TypeMapper.EmitGenericArguments(methodMetadata.GenericArguments),
                ReturnType = EmitReturnType(methodMetadata),
                Parameters = EmitParameters(methodMetadata.Parameters),
            };
            return methodModel;
        }

        internal static IEnumerable<DTG2MethodMetadata> EmitMethods(IEnumerable<MethodMetadata> methods)
        {
            return from MethodMetadata _currentMethod in methods
                   select MapToDTGModel(_currentMethod);
        }

        private static IEnumerable<DTG2ParameterMetadata> EmitParameters(IEnumerable<ParameterMetadata> parms)
        {
            return from parm in parms
                   select ParameterMapper.MapToDTGModel(parm);
        }
        private static DTG2TypeMetadata EmitReturnType(MethodMetadata method)
        {
            MethodMetadata methodInfo = method as MethodMetadata;
            if (methodInfo == null)
                return null;
            return TypeMapper.EmitReference(methodInfo.ReturnType);
        }
    }
}
