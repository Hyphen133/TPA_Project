using Database.Model;
using DataTransferGraph.Model;
using System.Collections.Generic;
using System.Linq;

namespace Database.DatabaseMapper
{
    public class DatabasePropertyMapper
    {
        public static DatabasePropertyMetadata MapToDatabase(DTGPropertyMetadata propertyMetadata)
        {
            DatabasePropertyMetadata propertyModel = new DatabasePropertyMetadata
            {
                Name = propertyMetadata.Name,
                TypeMetadata = SerializationTypeMapper.EmitReferenceDatabase(propertyMetadata.TypeMetadata)
            };
            return propertyModel;
        }

        internal static IEnumerable<DatabasePropertyMetadata> EmitPropertiesDatabase(IEnumerable<DTGPropertyMetadata> props)
        {
            return from prop in props
                   select MapToDatabase(prop);
        }


        public static DTGPropertyMetadata MapToDTG(DatabasePropertyMetadata propertyMetadata)
        {
            DTGPropertyMetadata propertyModel = new DTGPropertyMetadata
            {
                Name = propertyMetadata.Name,
                TypeMetadata = SerializationTypeMapper.EmitReferenceDTG(propertyMetadata.TypeMetadata)
            };
            return propertyModel;
        }

        internal static IEnumerable<DTGPropertyMetadata> EmitPropertiesDTG(IEnumerable<DatabasePropertyMetadata> props)
        {
            if (props == null) return null;
            return from prop in props
                   select MapToDTG(prop);
        }
    }
}
