using System.IO;
using DataSerializer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.DTGMapper;
using Logic.MEF;
using Logic.Model;
using Logic.Services;

namespace DataSerializerTests
{
    [TestClass]
    public class SerializationTest
    {
        private string path;

        [TestInitialize]
        public void TestInitialize()
        {
            path = Directory.GetCurrentDirectory();
        }

        [TestMethod]
        public void SerializeDeserializeTest_IfEverythingIsOk_ShouldBeOk()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string root = "Tests";
            while(!(path.Substring(path.Length - root.Length) == root))
            {
                path = path.Remove(path.Length - 1);
            }
            string filename = "\\TPA.ApplicationArchitecture.dll";
            string xmlName = "\\test.xml";
            string fullFilePath = path + filename;
            string fullXmlPath = path + xmlName;
            AssemblyMetadata assemblyMetaData = DataService.LoadAssembly(fullFilePath);
            ISerialize xmlSerialize = Mef.Container.GetExportedValue<ISerialize>();
            AssemblyMapper mp = new AssemblyMapper();
            xmlSerialize.Write(mp.MapToDTGModel(assemblyMetaData), fullXmlPath);
            AssemblyMetadata assemblyMetadata2 = mp.MapFromDTGModel(xmlSerialize.Read(fullXmlPath));
            //Assert.AreEqual(assemblyMetaData.Name, assemblyMetadata2.Name);
        }
    }
}
