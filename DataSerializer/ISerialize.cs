using DataTransferGraph2.Model;

namespace DataSerializer
{
    public interface ISerialize
    {
        DTG2AssemblyMetadata Read(string path);
        void Write(DTG2AssemblyMetadata assemblyModel, string path);
    }
}
