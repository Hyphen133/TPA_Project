using DataTransferGraph.Model;

namespace DataSerializer
{
    public interface ISerialize
    {
        DTGAssemblyMetadata Read(string path);
        void Write(DTGAssemblyMetadata assemblyModel, string path);
    }
}
