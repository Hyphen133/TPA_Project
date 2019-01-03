using DataSerializer.Model;
using DataTransferGraph2.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataSerializer.SerializationMapper
{
    public class SerializationPropertyMapper
    {
        public static XMLPropertyMetadata MapToXML(DTG2PropertyMetadata propertyMetadata)
        {
            XMLPropertyMetadata propertyModel = new XMLPropertyMetadata
            {
                Name = propertyMetadata.Name,
                TypeMetadata = SerializationTypeMapper.EmitReferenceXML(propertyMetadata.TypeMetadata)
            };
            return propertyModel;
        }

        internal static IEnumerable<XMLPropertyMetadata> EmitPropertiesXML(IEnumerable<DTG2PropertyMetadata> props)
        {
            return from prop in props
                   select MapToXML(prop);
        }


        public static DTG2PropertyMetadata MapToDTG(XMLPropertyMetadata propertyMetadata)
        {
            DTG2PropertyMetadata propertyModel = new DTG2PropertyMetadata
            {
                Name = propertyMetadata.Name,
                TypeMetadata = SerializationTypeMapper.EmitReferenceDTG(propertyMetadata.TypeMetadata)
            };
            return propertyModel;
        }

        internal static IEnumerable<DTG2PropertyMetadata> EmitPropertiesDTG(IEnumerable<XMLPropertyMetadata> props)
        {
            if (props == null) return null;
            return from prop in props
                   select MapToDTG(prop);
        }
    }
}
