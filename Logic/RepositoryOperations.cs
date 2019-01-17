using Database;
using DataSerializer;
using DataTransferGraph.Model;
using Logic.DTGMapper;
using Logic.MEF;
using Logic.Model;
using Tracing;

namespace Logic
{
    public class RepositoryOperations
    {
        public static void Save(AssemblyMetadata assembly, string address)
        {
            ISerialize serializer = new DatabaseOperations();// Mef.Container.GetExportedValue<ISerialize>();
            ITraceSource trace = new DatabaseTraceSource();
            DTGAssemblyMetadata pom = AssemblyMapper.MapToDTGModel(assembly);
            serializer.Save(pom, address + "\\test.xml");
            trace.TraceData(System.Diagnostics.TraceEventType.Information, 1, "Serialization Succeded");
        }

        public static AssemblyMetadata Read(string address)
        {
            ISerialize deserializer = new DatabaseOperations();// = Mef.Container.GetExportedValue<ISerialize>();
            return AssemblyMapper.MapToModel(deserializer.Read(address));
        }
    }
}
