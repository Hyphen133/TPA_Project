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
            using (var context = new DatabaseModelContext(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Radioaktywny\Desktop\TPA_Project\Database\Database.mdf; Integrated Security = True; Connect Timeout = 30"))
            {
                FeedContext(context, assemblyModel);
            }
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

        private static void FeedContext(DatabaseModelContext context, DatabaseAssemblyMetadata databaseAssemblyMetadata)
        {
            context.Assemblies.Add(databaseAssemblyMetadata);
            context.SaveChanges();
        }
    }    
}
