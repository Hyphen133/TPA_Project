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
                TypeMetadata = TypeMapper.EmitReference(propertyMetadata.TypeMetadata)
            };
            return propertyModel;
        }

        internal static IEnumerable<DTG2PropertyMetadata> EmitProperties(IEnumerable<PropertyMetadata> props)
        {
            return from prop in props
                   select MapToDTGModel(prop);
        }
    }
}
