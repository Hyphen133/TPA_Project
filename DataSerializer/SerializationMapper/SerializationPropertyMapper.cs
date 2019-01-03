using DataSerializer.Model;
using DataTransferGraph2.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataSerializer.SerializationMapper
{
    public class SerializationPropertyMapper
    {
        public static XMLPropertyMetadata MapToXMLModel(DTG2PropertyMetadata propertyMetadata)
        {
            XMLPropertyMetadata propertyModel = new XMLPropertyMetadata
            {
                Name = propertyMetadata.Name,
                TypeMetadata = SerializationTypeMapper.EmitReference(propertyMetadata.TypeMetadata)
            };
            return propertyModel;
        }

        internal static IEnumerable<XMLPropertyMetadata> EmitProperties(IEnumerable<DTG2PropertyMetadata> props)
        {
            return from prop in props
                   select MapToXMLModel(prop);
        }
    }
}
