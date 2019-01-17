using Database.DatabaseMapper;
using DataTransferGraph;
using DataTransferGraph.Model;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace Database
{
    [Export(typeof(ISerialize))]
    public class DatabaseOperations : ISerialize
    {
        public static string Path;

        public DTGAssemblyMetadata Read(string path)
        {
            using (var context = new DatabaseModelContext(Path))
            {
                context.Assemblies.Load();
                context.Namespaces.Load();
                context.Methods.Load();
                context.Parameters.Load();
                context.Properties.Load();
                context.Types.Load();                
                var ret = context.Assemblies.First();
                return DatabaseAssemblyMapper.MapToDTG(ret);             
            }
        }

        public void Save(DTGAssemblyMetadata assemblyModel, string path)
        {           
            using (var context = new DatabaseModelContext(Path))
            {
                context.Assemblies.Add(DatabaseAssemblyMapper.MapToDatabase(assemblyModel));
                context.SaveChanges();
            }
        }
    }
}
