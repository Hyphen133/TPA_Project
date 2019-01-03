using DataSerializer.Model;
using DataTransferGraph2.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataSerializer.SerializationMapper
{
    public class SerializationMethodMapper
    {
        public static XMLMethodMetadata MapToXMLModel(DTG2MethodMetadata methodMetadata)
        {
            XMLMethodMetadata methodModel = new XMLMethodMetadata
            {
                Name = methodMetadata.Name,
                GenericArguments = GetGenericArguments(methodMetadata),
                ReturnType = EmitReturnType(methodMetadata),
                Parameters = EmitParameters(methodMetadata.Parameters),
            };
            return methodModel;
        }

        private static List<XMLTypeMetadata> GetGenericArguments(DTG2MethodMetadata methodMetadata)
        {
            if (methodMetadata.GenericArguments == null)
                return null;
            return SerializationTypeMapper.EmitGenericArguments(methodMetadata.GenericArguments).ToList();
        }

        internal static IEnumerable<XMLMethodMetadata> EmitMethods(IEnumerable<DTG2MethodMetadata> methods)
        {
            return from DTG2MethodMetadata _currentMethod in methods
                   select MapToXMLModel(_currentMethod);
        }

        private static IEnumerable<XMLParameterMetadata> EmitParameters(IEnumerable<DTG2ParameterMetadata> parms)
        {
            return from parm in parms
                   select SerializationParameterMapper.MapToXMLModel(parm);
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
