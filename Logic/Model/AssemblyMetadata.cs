using DataTransferGraph;
using DataTransferGraph.Model;
using Logic.DTGMapper;
using Logic.MEF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using Tracing;

namespace Logic.Model
{
    public class AssemblyMetadata
    {
        public AssemblyMetadata()
        {

        }

        public AssemblyMetadata(Assembly assembly)
        {
            //Reseting dictonaries
            HelperDictonaries.resetDictonaries();

            m_Name = assembly.ManifestModule.Name;

            m_Namespaces = from Type _type in assembly.GetTypes()
                               //where _type.GetVisible()
                           group _type by _type.Namespace into _group
                           orderby _group.Key
                           select new NamespaceMetadata(_group.Key, _group);
        }

        private string m_Name;
        private IEnumerable<NamespaceMetadata> m_Namespaces;

        public IEnumerable<NamespaceMetadata> Namespaces { get => m_Namespaces; set => m_Namespaces = value; }
        public string Name { get => m_Name; set => m_Name = value; }

        public void Save(string address)
        {
            ISerialize serializer = Mef.Container.GetExportedValue<ISerialize>(ConfigurationManager.AppSettings["repository"]);
            ITraceSource trace = Mef.Container.GetExportedValue<ITraceSource>(ConfigurationManager.AppSettings["logging"]);
            DTGAssemblyMetadata pom = AssemblyMapper.MapToDTGModel(this);
            serializer.Save(pom, address);
            trace.TraceData(System.Diagnostics.TraceEventType.Information, 1, "Serialization Succeded");
        }
    }
}