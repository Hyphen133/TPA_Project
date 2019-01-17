using Database.DatabaseMapper;
using DataSerializer;
using DataTransferGraph.Model;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;

namespace Database
{
    [Export(typeof(ISerialize))]
    public class DatabaseOperations : ISerialize
    {
        public DTGAssemblyMetadata Read(string path)
        {
            using (var context = new DatabaseModelContext())
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
            DatabaseAssemblyMapper.MapToDatabase(assemblyModel);
        }
    }
}
