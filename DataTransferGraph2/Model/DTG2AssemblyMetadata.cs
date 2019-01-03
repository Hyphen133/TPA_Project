using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DataTransferGraph2.Model
{
    public class DTG2AssemblyMetadata
    {
        public DTG2AssemblyMetadata()
        {

        }

        public DTG2AssemblyMetadata(AssemblyMetadata assembly)
        {
            //Reseting dictonaries
            DTG2HelperDictonaries.ResetDictonaries();

            m_Name = assembly.Name;

            m_Namespaces = from NamespaceMetadata _namespace in assembly.Namespaces
                           select new DTG2NamespaceMetadata(_namespace.NamespaceName, _namespace.Types);
        }

        private string m_Name;
        private IEnumerable<DTG2NamespaceMetadata> m_Namespaces;

        public IEnumerable<DTG2NamespaceMetadata> Namespaces { get => m_Namespaces; set => m_Namespaces = value; }
        public string Name { get => m_Name; set => m_Name = value; }
    }
}