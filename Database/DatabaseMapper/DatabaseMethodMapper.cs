using Database.Model;
using DataTransferGraph.Model;
using System.Collections.Generic;
using System.Linq;

namespace Database.DatabaseMapper
{
    public class DatabaseMethodMapper
    {
        public static DatabaseMethodMetadata MapToDatabase(DTGMethodMetadata methodMetadata)
        {
            DatabaseMethodMetadata methodModel = new DatabaseMethodMetadata
            {
                Name = methodMetadata.Name,
                GenericArguments = SerializationTypeMapper.EmitGenericArgumentsDatabase(methodMetadata.GenericArguments),
                ReturnType = EmitReturnTypeDatabase(methodMetadata),
                Parameters = EmitParametersDatabase(methodMetadata.Parameters),
            };
            return methodModel;
        }

        internal static IEnumerable<DatabaseMethodMetadata> EmitMethodsDatabase(IEnumerable<DTGMethodMetadata> methods)
        {
            return from DTGMethodMetadata _currentMethod in methods
                   select MapToDatabase(_currentMethod);
        }

        private static IEnumerable<DatabaseParameterMetadata> EmitParametersDatabase(IEnumerable<DTGParameterMetadata> parms)
        {
            return from parm in parms
                   select DatabaseParameterMapper.MapToDatabase(parm);
        }
        private static DatabaseTypeMetadata EmitReturnTypeDatabase(DTGMethodMetadata method)
        {
            DTGMethodMetadata methodInfo = method as DTGMethodMetadata;
            if (methodInfo == null)
                return null;
            return SerializationTypeMapper.EmitReferenceDatabase(methodInfo.ReturnType);
        }

        public static DTGMethodMetadata MapToDTG(DatabaseMethodMetadata methodMetadata)
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

        internal static IEnumerable<DTGMethodMetadata> EmitMethodsDTG(IEnumerable<DatabaseMethodMetadata> methods)
        {
            if (methods == null) return null;
            return from DatabaseMethodMetadata _currentMethod in methods
                   select MapToDTG(_currentMethod);
        }

        private static IEnumerable<DTGParameterMetadata> EmitParametersDTG(IEnumerable<DatabaseParameterMetadata> parms)
        {
            return from parm in parms
                   select DatabaseParameterMapper.MapToDTG(parm);
        }
        private static DTGTypeMetadata EmitReturnTypeDTG(DatabaseMethodMetadata method)
        {
            DatabaseMethodMetadata methodInfo = method as DatabaseMethodMetadata;
            if (methodInfo == null)
                return null;
            return SerializationTypeMapper.EmitReferenceDTG(methodInfo.ReturnType);
        }
    }
}
