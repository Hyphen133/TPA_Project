using DataSerializer.SerializationMapper;
using DataSerializer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Runtime.Serialization;
using DataTransferGraph.Model;

namespace DataSerializer
{
    [Export(typeof(ISerialize))]
    public class XmlSerialize : ISerialize
    {
        [Import]
        SerializationAssemblyMapper am;

        //[Import]
        //static ITraceSource traceSource;

        //public static ITraceSource TraceSource { get => traceSource; set => traceSource = value; }

        public DTGAssemblyModel Read(string path)
        {
            XMLAssemblyMetadata model;

            DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(XMLAssemblyMetadata));
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                model = (XMLAssemblyMetadata)dataContractSerializer.ReadObject(fileStream);
            }
            return am.MapToLower(model);
        }

        public void Write(DTGAssemblyModel assemblyModel, string path)
        {
            XMLAssemblyMetadata assembly = am.MapToUpper(assemblyModel);
            List<Type> knownTypes = new List<Type>
            {
                typeof(XMLTypeMetadata),
                typeof(XMLNamespaceMetadata),
                typeof(XMLMethodMetadata),
                typeof(XMLParameterMetadata),
                typeof(XMLPropertyMetadata)
            };

            DataContractSerializer dataContractSerializer =
                new DataContractSerializer(typeof(XMLAssemblyMetadata));

            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    dataContractSerializer.WriteObject(fileStream, assembly);
                }
            }
            catch (Exception)
            {
                //if (traceSource != null)
                //{
                //    traceSource.TraceData(System.Diagnostics.TraceEventType.Error, 1, "Serialization failed");
                //}
            }
        }
    }
}
