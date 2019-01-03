using DataTransferGraph2.Model;
using Logic.Model;
using System.Collections.Generic;
using System.Linq;

namespace Logic.DTGMapper
{
    public class PropertyMapper
    {
        public static DTG2PropertyMetadata MapToDTGModel(PropertyMetadata propertyMetadata)
        {
            DTG2PropertyMetadata propertyModel = new DTG2PropertyMetadata
            {
                Name = propertyMetadata.Name,
                TypeMetadata = TypeMapper.EmitReferenceDTG(propertyMetadata.TypeMetadata)
            };
            return propertyModel;
        }

        internal static IEnumerable<DTG2PropertyMetadata> EmitPropertiesDTG(IEnumerable<PropertyMetadata> props)
        {
            return from prop in props
                   select MapToDTGModel(prop);
        }

        public static PropertyMetadata MapToModel(DTG2PropertyMetadata propertyMetadata)
        {
            PropertyMetadata propertyModel = new PropertyMetadata
            {
                Name = propertyMetadata.Name,
                TypeMetadata = TypeMapper.EmitReferenceModel(propertyMetadata.TypeMetadata)
            };
            return propertyModel;
        }

        internal static IEnumerable<PropertyMetadata> EmitPropertiesModel(IEnumerable<DTG2PropertyMetadata> props)
        {
            return from prop in props
                   select MapToModel(prop);
        }
    }
}
