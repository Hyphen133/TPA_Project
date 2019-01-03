using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Logic.Model;

namespace DataTransferGraph2.Model
{
    public class DTG2PropertyMetadata
    {
        public DTG2PropertyMetadata() { }

        internal static IEnumerable<DTG2PropertyMetadata> EmitProperties(IEnumerable<PropertyMetadata> props)
        {
            return from prop in props
                   select new DTG2PropertyMetadata(prop.Name, DTG2TypeMetadata.EmitReference(prop.TypeMetadata));
        }

        #region private
        private string m_Name;
        private DTG2TypeMetadata m_TypeMetadata;

        public string Name { get => m_Name; set => m_Name = value; }
        public DTG2TypeMetadata TypeMetadata { get => m_TypeMetadata; set => m_TypeMetadata = value; }

        private DTG2PropertyMetadata(string propertyName, DTG2TypeMetadata propertyType)
        {
            m_Name = propertyName;
            m_TypeMetadata = propertyType;
        }
        #endregion
    }
}