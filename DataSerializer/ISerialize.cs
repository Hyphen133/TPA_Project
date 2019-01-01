using DataTransferGraph.Model;

namespace DataSerializer
{
    public interface ISerialize
    {
        DTGAssemblyModel Read(string path);
        void Write(DTGAssemblyModel assemblyModel, string path);
    }
}
