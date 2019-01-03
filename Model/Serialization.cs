using DataSerializer;
using DataTransferGraph2.Model;
using Logic.DTGMapper;
using Logic.MEF;
using Logic.Model;

namespace Logic
{
    public class Serialization
    {
        public static void Serialize(AssemblyMetadata assembly, string path)
        {
            ISerialize serializer = Mef.Container.GetExportedValue<ISerialize>();
            DTG2AssemblyMetadata pom = AssemblyMapper.MapToDTGModel(assembly);
            serializer.Write(pom, path + "\\test.xml");
        }

        public static AssemblyMetadata Deserialize(string path)
        {
            ISerialize deserializer = Mef.Container.GetExportedValue<ISerialize>();
            return AssemblyMapper.MapToModel(deserializer.Read(path));
        }
    }
}
