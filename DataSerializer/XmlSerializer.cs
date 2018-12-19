using DataSerializer.SerializationMapper;
using Data.SerializationModel;
using Model.Model;
using Model.Tracing;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Runtime.Serialization;

namespace DataSerializer
{
    [Export(typeof(ISerialize))]
    public class XmlSerialize : ISerialize
    {
        [Import]
        AssemblyMapper am;

        [Import]
        static ITraceSource traceSource;

        public static ITraceSource TraceSource { get => traceSource; set => traceSource = value; }

        public object Read(Type type, string path)
        {
            SerializableAssemblyModel model;
            List<Type> knownTypes = new List<Type>
            {
                typeof(SerializableTypeModel),
                typeof(SerializableNamespaceModel),
                typeof(SerializableMethodModel),
                typeof(SerializableParameterModel),
                typeof(SerializablePropertyModel)
            };

            DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(SerializableAssemblyModel), knownTypes);
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                model = (SerializableAssemblyModel)dataContractSerializer.ReadObject(fileStream);
            }
            return am.MapToUpper(model);
        }

        public void Write(object obj, string path)
        {
            SerializableAssemblyModel assembly = (SerializableAssemblyModel)am.MapToLower((AssemblyMetadata)obj);
            List<Type> knownTypes = new List<Type>
            {
                typeof(SerializableTypeModel),
                typeof(SerializableNamespaceModel),
                typeof(SerializableMethodModel),
                typeof(SerializableParameterModel),
                typeof(SerializablePropertyModel)
            };

            DataContractSerializer dataContractSerializer =
                new DataContractSerializer(typeof(SerializableAssemblyModel), knownTypes);

            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    dataContractSerializer.WriteObject(fileStream, assembly);
                }
            }
            catch (Exception)
            {
                if (traceSource != null)
                {
                    traceSource.TraceData(System.Diagnostics.TraceEventType.Error, 1, "Serialization failed");
                }
            }
        }
    }
}
