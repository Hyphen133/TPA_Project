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

        public static AssemblyMetadata MapToModel(DTG2AssemblyMetadata assemblyMetadata)
        {
            HelperDictonaries.ResetDictonaries();

            AssemblyMetadata assemblyModel = new AssemblyMetadata
            {
                Name = assemblyMetadata.Name,
                Namespaces = from DTG2NamespaceMetadata _namespace in assemblyMetadata.Namespaces
                             select NamespaceMapper.MapToModel(_namespace)
            };
            return assemblyModel;
        }
    }
}
