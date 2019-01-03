using DataSerializer.Model;
using DataTransferGraph2.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataSerializer.SerializationMapper
{
    public class SerializationMethodMapper
    {
        public static XMLMethodMetadata MapToXML(DTG2MethodMetadata methodMetadata)
        {
            XMLMethodMetadata methodModel = new XMLMethodMetadata
            {
                Name = methodMetadata.Name,
                GenericArguments = SerializationTypeMapper.EmitGenericArguments(methodMetadata.GenericArguments),
                ReturnType = EmitReturnType(methodMetadata),
                Parameters = EmitParameters(methodMetadata.Parameters),
            };
            return methodModel;
        }

        internal static IEnumerable<XMLMethodMetadata> EmitMethods(IEnumerable<DTG2MethodMetadata> methods)
        {
            return from DTG2MethodMetadata _currentMethod in methods
                   select MapToXML(_currentMethod);
        }

        private static IEnumerable<XMLParameterMetadata> EmitParameters(IEnumerable<DTG2ParameterMetadata> parms)
        {
            return from parm in parms
                   select SerializationParameterMapper.MapToXML(parm);
        }
        private static XMLTypeMetadata EmitReturnType(DTG2MethodMetadata method)
        {
            DTG2MethodMetadata methodInfo = method as DTG2MethodMetadata;
            if (methodInfo == null)
                return null;
            return SerializationTypeMapper.EmitReference(methodInfo.ReturnType);
        }
    }
}
