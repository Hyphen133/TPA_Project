using DataTransferGraph.Model;
using Logic.Model;
using System.ComponentModel.Composition;
using System.Linq;

namespace Logic.DTGMapper
{
    public class AssemblyMapper
    {
        public static DTGAssemblyMetadata MapToDTGModel(AssemblyMetadata assemblyMetadata)
        {
            HelperDictonaries.ResetDictonaries();

            DTGAssemblyMetadata assemblyModel = new DTGAssemblyMetadata
            {
                Name = assemblyMetadata.Name,
                Namespaces = from NamespaceMetadata _namespace in assemblyMetadata.Namespaces
                             select NamespaceMapper.MapToDTGModel(_namespace)
            };
            return assemblyModel;
        }

        public static AssemblyMetadata MapToModel(DTGAssemblyMetadata assemblyMetadata)
        {
            HelperDictonaries.ResetDictonaries();

            AssemblyMetadata assemblyModel = new AssemblyMetadata
            {
                Name = assemblyMetadata.Name,
                Namespaces = from DTGNamespaceMetadata _namespace in assemblyMetadata.Namespaces
                             select NamespaceMapper.MapToModel(_namespace)
            };
            return assemblyModel;
        }
    }
}
