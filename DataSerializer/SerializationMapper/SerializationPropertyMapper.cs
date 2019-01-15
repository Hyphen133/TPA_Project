using DataSerializer.Model;
using DataTransferGraph.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataSerializer.SerializationMapper
{
    public class SerializationPropertyMapper
    {
        public static XMLPropertyMetadata MapToXML(DTGPropertyMetadata propertyMetadata)
        {
            XMLPropertyMetadata propertyModel = new XMLPropertyMetadata
            {
                Name = propertyMetadata.Name,
                TypeMetadata = SerializationTypeMapper.EmitReferenceXML(propertyMetadata.TypeMetadata)
            };
            return propertyModel;
        }

        internal static IEnumerable<XMLPropertyMetadata> EmitPropertiesXML(IEnumerable<DTGPropertyMetadata> props)
        {
            return from prop in props
                   select MapToXML(prop);
        }


        public static DTGPropertyMetadata MapToDTG(XMLPropertyMetadata propertyMetadata)
        {
            DTGPropertyMetadata propertyModel = new DTGPropertyMetadata
            {
                Name = propertyMetadata.Name,
                TypeMetadata = SerializationTypeMapper.EmitReferenceDTG(propertyMetadata.TypeMetadata)
            };
            return propertyModel;
        }

        internal static IEnumerable<DTGPropertyMetadata> EmitPropertiesDTG(IEnumerable<XMLPropertyMetadata> props)
        {
            if (props == null) return null;
            return from prop in props
                   select MapToDTG(prop);
        }
    }
}
