using Database;
using DataSerializer;
using DataTransferGraph.Model;
using Logic.DTGMapper;
using Logic.MEF;
using Logic.Model;

namespace Logic
{
    public class Serialization
    {
        public static void Serialize(AssemblyMetadata assembly, string path)
        {
            ISerialize serializer = new DatabaseOperations();//Mef.Container.GetExportedValue<ISerialize>();
            DTGAssemblyMetadata pom = AssemblyMapper.MapToDTGModel(assembly);
            serializer.Save(pom, path + "\\test.xml");
        }

        public static AssemblyMetadata Deserialize(string path)
        {
            ISerialize deserializer = new DatabaseOperations();//= Mef.Container.GetExportedValue<ISerialize>();
            return AssemblyMapper.MapToModel(deserializer.Read(path));
        }
    }
}
