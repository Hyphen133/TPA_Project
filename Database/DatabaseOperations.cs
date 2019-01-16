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
            throw new NotImplementedException();
        }

        public void Save(DTGAssemblyMetadata assemblyModel, string path)
        {
            DatabaseAssemblyMapper.MapToDatabase(assemblyModel);
        }
    }
}
