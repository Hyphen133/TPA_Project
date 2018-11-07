using System;
using System.Diagnostics;
using System.IO;
using TPAv2;

namespace Tests
{
    public class FileTraceSource : ITraceSource
    {
        private String filepath;

        public FileTraceSource(string filepath)
        {
            FileInfo f = new FileInfo(filepath);
            if(!f.Exists)
            {
                throw new FileNotFoundException();
            }
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
