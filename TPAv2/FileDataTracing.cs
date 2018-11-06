using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPAv2
{
    public class FileTraceSource : ITraceSource
    {
        private String filepath;

        public FileTraceSource(string filepath)
        {
            this.filepath = filepath;
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
