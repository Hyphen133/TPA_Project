using System;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace Tracing
{
    [Export("FileTraceSource", typeof(ITraceSource))]
    public class FileTraceSource : ITraceSource
    {
        public static string filepath = ConfigurationManager.AppSettings["filepath"];

        public string Filepath
        {
            get => filepath;
            set
            {
                FileInfo f = new FileInfo(value);
                if (!f.Exists)
                {
                    throw new FileNotFoundException();
                }
                filepath = value;
            }
        }

        public void TraceData(TraceEventType eventType, int id, object data)
        {
            using (FileStream fs = new FileStream(filepath, FileMode.Append))
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.Write("[" + DateTime.Now + "]  ");
                writer.Write(eventType.ToString() + ": " + data.ToString());
            }

        }
    }
}
