using Database.Model;
using DataTransferGraph.Model;
using System.ComponentModel.Composition;
using System.Linq;

namespace Database.DatabaseMapper
{
    [Export]
    class DatabaseAssemblyMapper
    {
        public static DatabaseAssemblyMetadata MapToDatabase(DTGAssemblyMetadata assemblyMetadata)
        {
            HelperDictonaries.ResetDictonaries();

            DatabaseAssemblyMetadata assemblyModel = new DatabaseAssemblyMetadata
            {
                Name = assemblyMetadata.Name,
                Namespaces = from DTGNamespaceMetadata _namespace in assemblyMetadata.Namespaces
                             select DatabaseNamespaceMapper.MapToDatabase(_namespace)
            };
            assemblyModel.SetValues();
            return assemblyModel;
        }

        public static DTGAssemblyMetadata MapToDTG(DatabaseAssemblyMetadata assemblyMetadata)
        {
            HelperDictonaries.ResetDictonaries();

            DTGAssemblyMetadata assemblyModel = new DTGAssemblyMetadata
            {
                Name = assemblyMetadata.Name,
                Namespaces = from DatabaseNamespaceMetadata _namespace in assemblyMetadata.NamespacesL
                             select DatabaseNamespaceMapper.MapToDTG(_namespace)
            };
            return assemblyModel;
        }
    }
}
