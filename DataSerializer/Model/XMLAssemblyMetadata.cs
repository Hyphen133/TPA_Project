﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataSerializer.Model
{
    [DataContract(IsReference = true)]
    public class XMLAssemblyMetadata
    {
        [DataMember]
        private string m_Name;
        [DataMember]
        private List<XMLNamespaceMetadata> m_Namespaces;

        public List<XMLNamespaceMetadata> Namespaces { get => m_Namespaces; set => m_Namespaces = value; }
        public string Name { get => m_Name; set => m_Name = value; }
    }
}