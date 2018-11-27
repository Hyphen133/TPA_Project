using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using TPAv2;

namespace Serializer
{
    public class XmlSerialize : ISerialize
    {
        static ITraceSource traceSource;
        private string filePath;

        public static ITraceSource TraceSource { get => traceSource; set => traceSource = value; }
        public string FilePath { get => filePath; set => filePath = value; }

        public XmlSerialize(ITraceSource traceSource, string filePath)
        {
            TraceSource = traceSource;
            FilePath = filePath;
        }

        public object Read(Type type)
        {
            DataContractSerializer serializer = new DataContractSerializer(type);
            object obj = null;

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                XmlDictionaryReaderQuotas dictReader = new XmlDictionaryReaderQuotas();
                dictReader.MaxDepth = 1000;
                XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, dictReader);

                obj = serializer.ReadObject(reader);
            }
            return obj;
        }

        public void Write(object obj)
        {
            DataContractSerializer serializer = new DataContractSerializer(obj.GetType());

            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    serializer.WriteObject(fs, obj);
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
