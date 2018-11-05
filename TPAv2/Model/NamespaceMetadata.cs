
using System;
using System.Collections.Generic;
using System.Linq;
using TPAv2.Model;

namespace TPA.Reflection.Model
{
  public class NamespaceMetadata
  {

    public NamespaceMetadata(string name, IEnumerable<Type> types)
    {
      m_NamespaceName = name;


            //May be even more beneficial to create all types from all namespaces beforehand
            foreach (var type in types)
            {
                HelperDictonaries.TypeDictonary[type] = new TypeMetadata(type.Name, this.m_NamespaceName);
            }
      m_Types = from type in types orderby type.Name select TypeMetadata.fillType(HelperDictonaries.TypeDictonary[type], type);

    }

    private string m_NamespaceName;
    private IEnumerable<TypeMetadata> m_Types;

        public string NamespaceName { get => m_NamespaceName; set => m_NamespaceName = value; }
        public IEnumerable<TypeMetadata> Types { get => m_Types; set => m_Types = value; }
    }
}