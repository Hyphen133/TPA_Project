using Database;
using DataTransferGraph2;
using System;
using System.Composition;
using System.Diagnostics;

namespace Tracing
{
    [Export(typeof(ITraceSource))]
    public class DatabaseTraceSource : ITraceSource
    {
        public void TraceData(TraceEventType eventType, int id, object data)
        {
            var repository = new MessageRepository();
            DTGMessage message = new DTGMessage
            {
                MessageString = ("[" + DateTime.Now + "]  " + eventType.ToString() + ": " + data.ToString())
            };
            repository.AddMessage(message);
        }
    }
}
