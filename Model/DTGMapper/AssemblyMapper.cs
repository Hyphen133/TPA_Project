using DataTransferGraph2.Model;
using Logic.Model;
using System.ComponentModel.Composition;
using System.Linq;

namespace Logic.DTGMapper
{
    [Export]
    public class AssemblyMapper
    {
        public static DTG2AssemblyMetadata MapToDTGModel(AssemblyMetadata assemblyMetadata)
        {
            HelperDictonaries.ResetDictonaries();

            DTG2AssemblyMetadata assemblyModel = new DTG2AssemblyMetadata
            {
                Name = assemblyMetadata.Name,
                Namespaces = from NamespaceMetadata _namespace in assemblyMetadata.Namespaces
                             select NamespaceMapper.MapToDTGModel(_namespace)
            };
            return assemblyModel;
        }
    }
}
