
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Runtime.Serialization;

namespace TPA.Reflection.Model
{
  [DataContract(IsReference=true)]
  public class PropertyMetadata
  {

    internal static IEnumerable<PropertyMetadata> EmitProperties(IEnumerable<PropertyInfo> props)
    {
      return from prop in props
             where prop.GetGetMethod().GetVisible() || prop.GetSetMethod().GetVisible()
             select new PropertyMetadata(prop.Name, TypeMetadata.EmitReference(prop.PropertyType));
    }

    #region private
    [DataMember]
    private string m_Name;
    [DataMember]
    private TypeMetadata m_TypeMetadata;


        public string Name { get => m_Name; set => m_Name = value; }
        public TypeMetadata TypeMetadata { get => m_TypeMetadata; set => m_TypeMetadata = value; }


        private PropertyMetadata(string propertyName, TypeMetadata propertyType)
    {
      m_Name = propertyName;
      m_TypeMetadata = propertyType;
    }
    #endregion

  }
}