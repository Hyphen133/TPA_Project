using DataTransferGraph.Model;

namespace DataSerializer
{
    public interface ISerialize
    {
        DTGAssemblyMetadata Read(string path);
        void Save(DTGAssemblyMetadata assemblyModel, string path);
    }
}
