using DataTransferGraph.Model;
using Logic.Model;
using System.Collections.Generic;
using System.Linq;

namespace Logic.DTGMapper
{
    public class PropertyMapper
    {
        public static DTGPropertyMetadata MapToDTGModel(PropertyMetadata propertyMetadata)
        {
            DTGPropertyMetadata propertyModel = new DTGPropertyMetadata
            {
                Name = propertyMetadata.Name,
                TypeMetadata = TypeMapper.EmitReferenceDTG(propertyMetadata.TypeMetadata)
            };
            return propertyModel;
        }

        internal static IEnumerable<DTGPropertyMetadata> EmitPropertiesDTG(IEnumerable<PropertyMetadata> props)
        {
            return from prop in props
                   select MapToDTGModel(prop);
        }

        public static PropertyMetadata MapToModel(DTGPropertyMetadata propertyMetadata)
        {
            PropertyMetadata propertyModel = new PropertyMetadata
            {
                Name = propertyMetadata.Name,
                TypeMetadata = TypeMapper.EmitReferenceModel(propertyMetadata.TypeMetadata)
            };
            return propertyModel;
        }

        internal static IEnumerable<PropertyMetadata> EmitPropertiesModel(IEnumerable<DTGPropertyMetadata> props)
        {
            if (props == null) return null;
            return from prop in props
                   select MapToModel(prop);
        }
    }
}
