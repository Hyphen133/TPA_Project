using DataSerializer.Model;
using DataTransferGraph.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataSerializer.SerializationMapper
{
    public class SerializationMethodMapper
    {
        public static XMLMethodMetadata MapToXML(DTGMethodMetadata methodMetadata)
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

        internal static IEnumerable<XMLMethodMetadata> EmitMethodsXML(IEnumerable<DTGMethodMetadata> methods)
        {
            return from DTGMethodMetadata _currentMethod in methods
                   select MapToXML(_currentMethod);
        }

        private static IEnumerable<XMLParameterMetadata> EmitParametersXML(IEnumerable<DTGParameterMetadata> parms)
        {
            return from parm in parms
                   select SerializationParameterMapper.MapToXML(parm);
        }
        private static XMLTypeMetadata EmitReturnTypeXML(DTGMethodMetadata method)
        {
            DTGMethodMetadata methodInfo = method as DTGMethodMetadata;
            if (methodInfo == null)
                return null;
            return SerializationTypeMapper.EmitReferenceXML(methodInfo.ReturnType);
        }

        public static DTGMethodMetadata MapToDTG(XMLMethodMetadata methodMetadata)
        {
            DTGMethodMetadata methodModel = new DTGMethodMetadata
            {
                Name = methodMetadata.Name,
                GenericArguments = SerializationTypeMapper.EmitGenericArgumentsDTG(methodMetadata.GenericArgumentsL),
                ReturnType = EmitReturnTypeDTG(methodMetadata),
                Parameters = EmitParametersDTG(methodMetadata.ParametersL),
            };
            return methodModel;
        }

        internal static IEnumerable<DTGMethodMetadata> EmitMethodsDTG(IEnumerable<XMLMethodMetadata> methods)
        {
            if (methods == null) return null;
            return from XMLMethodMetadata _currentMethod in methods
                   select MapToDTG(_currentMethod);
        }

        private static IEnumerable<DTGParameterMetadata> EmitParametersDTG(IEnumerable<XMLParameterMetadata> parms)
        {
            return from parm in parms
                   select SerializationParameterMapper.MapToDTG(parm);
        }
        private static DTGTypeMetadata EmitReturnTypeDTG(XMLMethodMetadata method)
        {
            XMLMethodMetadata methodInfo = method as XMLMethodMetadata;
            if (methodInfo == null)
                return null;
            return SerializationTypeMapper.EmitReferenceDTG(methodInfo.ReturnType);
        }
    }
}
