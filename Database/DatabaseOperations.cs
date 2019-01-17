using Database.DatabaseMapper;
using DataSerializer;
using DataTransferGraph.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    [Export(typeof(ISerialize))]
    public class DatabaseOperations : ISerialize
    {
        public DTGAssemblyMetadata Read(string path)
        {
            using (var context = new DatabaseModelContext(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Radioaktywny\Desktop\TPA_Project\Database\Database.mdf; Integrated Security = True; Connect Timeout = 30"))
            {
                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;
                var a = context.Namespaces.ToList();
                return DatabaseAssemblyMapper.MapToDTG(context.Assemblies.ToList()[0]);                
            }
        }

        public void Save(DTGAssemblyMetadata assemblyModel, string path)
        {
            DatabaseAssemblyMapper.MapToDatabase(assemblyModel);
        }
    }
}
