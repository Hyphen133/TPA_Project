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
            ISerialize serializer = Mef.Container.GetExportedValue<ISerialize>();
            AssemblyMapper am = new AssemblyMapper();
            DTGAssemblyModel pom = am.MapToDTGModel(assembly);
            serializer.Write(pom, path + "\\test.xml");
        }

        public static AssemblyMetadata Deserialize(string path)
        {
            ISerialize deserializer = Mef.Container.GetExportedValue<ISerialize>();
            AssemblyMapper am = new AssemblyMapper();
            return am.MapFromDTGModel(deserializer.Read(path));
        }
    }
}
