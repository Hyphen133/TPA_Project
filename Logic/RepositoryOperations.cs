using Database;
using DataSerializer;
using DataTransferGraph;
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
            ISerialize serializer = Mef.Container.GetExportedValue<ISerialize>(Configuration.configuredValues[typeof(ISerialize)]);
            ITraceSource trace = Mef.Container.GetExportedValue<ITraceSource>(Configuration.configuredValues[typeof(ITraceSource)]);
            DTGAssemblyMetadata pom = AssemblyMapper.MapToDTGModel(assembly);
            serializer.Save(pom, address);
            trace.TraceData(System.Diagnostics.TraceEventType.Information, 1, "Serialization Succeded");
        }

        public static AssemblyMetadata Read(string address)
        {
            ISerialize deserializer = Mef.Container.GetExportedValue<ISerialize>(Configuration.configuredValues[typeof(ISerialize)]);
            return AssemblyMapper.MapToModel(deserializer.Read(address));
        }
    }
}
