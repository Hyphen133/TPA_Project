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
                GenericArguments = SerializationTypeMapper.EmitGenericArgumentsXML(methodMetadata.GenericArguments),
                ReturnType = EmitReturnTypeXML(methodMetadata),
                Parameters = EmitParametersXML(methodMetadata.Parameters),
            };
            return methodModel;
        }

        internal static IEnumerable<XMLMethodMetadata> EmitMethodsXML(IEnumerable<DTG2MethodMetadata> methods)
        {
            return from DTG2MethodMetadata _currentMethod in methods
                   select MapToXML(_currentMethod);
        }

        private static IEnumerable<XMLParameterMetadata> EmitParametersXML(IEnumerable<DTG2ParameterMetadata> parms)
        {
            return from parm in parms
                   select SerializationParameterMapper.MapToXML(parm);
        }
        private static XMLTypeMetadata EmitReturnTypeXML(DTG2MethodMetadata method)
        {
            DTG2MethodMetadata methodInfo = method as DTG2MethodMetadata;
            if (methodInfo == null)
                return null;
            return SerializationTypeMapper.EmitReferenceXML(methodInfo.ReturnType);
        }

        public static DTG2MethodMetadata MapToDTG(XMLMethodMetadata methodMetadata)
        {
            DTG2MethodMetadata methodModel = new DTG2MethodMetadata
            {
                Name = methodMetadata.Name,
                GenericArguments = SerializationTypeMapper.EmitGenericArgumentsDTG(methodMetadata.GenericArgumentsL),
                ReturnType = EmitReturnTypeDTG(methodMetadata),
                Parameters = EmitParametersDTG(methodMetadata.ParametersL),
            };
            return methodModel;
        }

        internal static IEnumerable<DTG2MethodMetadata> EmitMethodsDTG(IEnumerable<XMLMethodMetadata> methods)
        {
            return from XMLMethodMetadata _currentMethod in methods
                   select MapToDTG(_currentMethod);
        }

        private static IEnumerable<DTG2ParameterMetadata> EmitParametersDTG(IEnumerable<XMLParameterMetadata> parms)
        {
            return from parm in parms
                   select SerializationParameterMapper.MapToDTG(parm);
        }
        private static DTG2TypeMetadata EmitReturnTypeDTG(XMLMethodMetadata method)
        {
            XMLMethodMetadata methodInfo = method as XMLMethodMetadata;
            if (methodInfo == null)
                return null;
            return SerializationTypeMapper.EmitReferenceDTG(methodInfo.ReturnType);
        }
    }
}
