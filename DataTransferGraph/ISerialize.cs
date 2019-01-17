using DataTransferGraph.Model;

namespace DataTransferGraph
{
    public interface ISerialize
    {
        DTGAssemblyMetadata Read(string path);
        void Save(DTGAssemblyMetadata assemblyModel, string path);
    }
}
