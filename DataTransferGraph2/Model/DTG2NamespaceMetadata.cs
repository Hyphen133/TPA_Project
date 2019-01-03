using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataTransferGraph2.Model
{
    public class DTG2NamespaceMetadata
    {
        public DTG2NamespaceMetadata() { }

        public DTG2NamespaceMetadata(string name, IEnumerable<TypeMetadata> types)
        {
            m_NamespaceName = name;
            //May be even more beneficial to create all types from all namespaces beforehand
            foreach (var type in types)
            {
                DTG2HelperDictonaries.TypeDictonary[type] = new DTG2TypeMetadata(type.TypeName, this.m_NamespaceName);
            }
            m_Types = from type in types orderby type.TypeName select DTG2TypeMetadata.fillType(DTG2HelperDictonaries.TypeDictonary[type], type);
        }

        private string m_NamespaceName;
        private IEnumerable<DTG2TypeMetadata> m_Types;

        public string NamespaceName { get => m_NamespaceName; set => m_NamespaceName = value; }
        public IEnumerable<DTG2TypeMetadata> Types { get => m_Types; set => m_Types = value; }
    }
}