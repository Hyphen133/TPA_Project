using Data;
using Model.Model;

namespace DataSerializer
{
    public interface IModelMapper
    {
        AssemblyMetadata MapToUpper(IAssemblyModel model);
        IAssemblyModel MapToLower(AssemblyMetadata model);
    }
}
