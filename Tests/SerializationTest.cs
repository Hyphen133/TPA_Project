using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Model;
using Model.Services;
using DataSerializer;
using Model.MEF;

namespace Tests
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
                Console.WriteLine(path);
            }

            Console.WriteLine(path);
            string filename = "\\TPA.ApplicationArchitecture.dll";
            string xmlName = "\\test.xml";
            string fullFilePath = path + filename;
            string fullXmlPath = path + xmlName;
            AssemblyMetadata assemblyMetaData = DataService.LoadAssembly(fullFilePath);
            //ISerialize xmlSerialize = new XmlSerialize(fullXmlPath);
            ISerialize xmlSerialize = Mef.Container.GetExportedValue<ISerialize>();
            xmlSerialize.Write(assemblyMetaData, fullXmlPath);
            AssemblyMetadata assemblyMetadata2 = (AssemblyMetadata)xmlSerialize.Read(typeof(AssemblyMetadata), fullXmlPath);
            Assert.AreEqual(assemblyMetaData.Name, assemblyMetadata2.Name);
        }
    }
}
