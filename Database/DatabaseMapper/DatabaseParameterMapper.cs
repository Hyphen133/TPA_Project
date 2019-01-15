﻿using Database.Model;
using DataTransferGraph.Model;

namespace Database.DatabaseMapper
{
    public class DatabaseParameterMapper
    {
        public static DatabaseParameterMetadata MapToDatabase(DTGParameterMetadata parameterMetadata)
        {
            DatabaseParameterMetadata parameterModel = new DatabaseParameterMetadata
            {
                Name = parameterMetadata.Name,
                TypeMetadata = SerializationTypeMapper.EmitReferenceDatabase(parameterMetadata.TypeMetadata),
            };
            return parameterModel;
        }

        public static DTGParameterMetadata MapToDTG(DatabaseParameterMetadata parameterMetadata)
        {
            DTGParameterMetadata parameterModel = new DTGParameterMetadata
            {
                Name = parameterMetadata.Name,
                TypeMetadata = SerializationTypeMapper.EmitReferenceDTG(parameterMetadata.TypeMetadata),
            };
            return parameterModel;
        }
    }
}