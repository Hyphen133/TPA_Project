using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TPA.Reflection.Model;

namespace TPAv2.Services
{
    public class XmlSerialize
    {
        static ITraceSource traceSource;

        public static ITraceSource TraceSource { get => traceSource; set => traceSource = value; }

        public XmlSerialize(ITraceSource traceSource)
        {
            TraceSource = traceSource;
        }

        public void SerializeAssembly(AssemblyMetadata assembly, String filepath)
        {
            DataContractSerializer serializer = new DataContractSerializer(assembly.GetType());

            try
            {
                using (FileStream fs = new FileStream(filepath, FileMode.Create))
                {
                    serializer.WriteObject(fs, assembly);
                }
            }catch(Exception e)
            {
                if (traceSource != null)
                {
                    traceSource.TraceData(System.Diagnostics.TraceEventType.Error, 1, "Assembly serialization failed");
                }
            }
            
        }

        public AssemblyMetadata DeserializeAssembly(String filepath)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(AssemblyMetadata));


            AssemblyMetadata assemblyMetadata = null;
            using (FileStream fs = new FileStream(filepath, FileMode.Open))
            {
                XmlDictionaryReaderQuotas dictReader = new XmlDictionaryReaderQuotas();
                dictReader.MaxDepth = 1000;
                XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, dictReader);

                assemblyMetadata = (AssemblyMetadata)serializer.ReadObject(reader);
            }
            return assemblyMetadata;
        }
    }
}
