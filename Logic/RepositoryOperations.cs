using DataTransferGraph;
using Logic.DTGMapper;
using Logic.MEF;
using Logic.Model;
using System.Configuration;

namespace Logic
{
    public class RepositoryOperations
    {
        public static AssemblyMetadata Read(string address)
        {
            ISerialize deserializer = Mef.Container.GetExportedValue<ISerialize>(ConfigurationManager.AppSettings["repository"]);
            return AssemblyMapper.MapToModel(deserializer.Read(address));
        }
    }
}
