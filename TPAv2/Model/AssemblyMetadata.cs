﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using TPAv2.Model;

namespace TPA.Reflection.Model
{
  [DataContract(IsReference=true)]
  public class AssemblyMetadata
  {

    public AssemblyMetadata(Assembly assembly)
    {
            //Reseting dictonaries
            HelperDictonaries.resetDictonaries();

      m_Name = assembly.ManifestModule.Name;


      m_Namespaces = from Type _type in assembly.GetTypes()
                     //where _type.GetVisible()
                     group _type by _type.GetNamespace() into _group
                     orderby _group.Key
                     select new NamespaceMetadata(_group.Key, _group);
    }



    [DataMember]
    private string m_Name;
    [DataMember]
    private IEnumerable<NamespaceMetadata> m_Namespaces;

    public IEnumerable<NamespaceMetadata> Namespaces { get => m_Namespaces; set => m_Namespaces = value; }
    public string Name { get => m_Name; set => m_Name = value; }
    }
}