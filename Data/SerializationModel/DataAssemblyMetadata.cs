using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Data
{
  [DataContract(IsReference=true)]
  public class AssemblyMetadata
  {
    [DataMember]
    private string m_Name;
    [DataMember]
    private IEnumerable<DataNamespaceMetadata> m_Namespaces;

    public IEnumerable<DataNamespaceMetadata> Namespaces { get => m_Namespaces; set => m_Namespaces = value; }
    public string Name { get => m_Name; set => m_Name = value; }
    }
}