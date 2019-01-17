using Database.Model;
using DataTransferGraph.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Composition;
using System.Linq;

namespace Database.DatabaseMapper
{
    [Export]
    public class DatabaseAssemblyMapper
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
            using (var context = new DatabaseModelContext())
            {
                FeedContext(context, assemblyModel);
            }
            return assemblyModel;
        }

        public static DTGAssemblyMetadata MapToDTG(DatabaseAssemblyMetadata assemblyMetadata)
        {
            HelperDictonaries.ResetDictonaries();

            using (var context = new DatabaseModelContext())
            {
                var ns = context.Namespaces.Include(n => n.TypesL).ToList();
                DTGAssemblyMetadata assemblyModel = new DTGAssemblyMetadata
                {
                    Name = assemblyMetadata.Name,
                    Namespaces = from DatabaseNamespaceMetadata _namespace in ns
                                 select DatabaseNamespaceMapper.MapToDTG(_namespace)
                };
                return assemblyModel;
            }
        }

        private static void FeedContext(DatabaseModelContext context, DatabaseAssemblyMetadata databaseAssemblyMetadata)
        {
            context.Assemblies.Add(databaseAssemblyMetadata);
            context.SaveChanges();
        }
    }    
}
