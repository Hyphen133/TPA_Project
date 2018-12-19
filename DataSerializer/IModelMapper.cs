using Model.Model;
using System.ComponentModel.Composition;

namespace DataSerializer
{
    //[InheritedExport(typeof(IModelMapper))]
    public interface IModelMapper
    {
        AssemblyMetadata MapToUpper(IAssemblyModel model);
        IAssemblyModel MapToLower(AssemblyMetadata model);
    }
}
