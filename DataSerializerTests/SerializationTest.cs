using System.IO;
using DataSerializer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.DTGMapper;
using Logic.MEF;
using Logic.Model;
using Logic.Services;
using System;
using DataTransferGraph.Model;
using DataTransferGraph;

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
                Console.WriteLine(path);
                path = path.Remove(path.Length - 1);
            }
            string filename = "\\TPA.ApplicationArchitecture.dll";
            string xmlName = "\\test.xml";
            string fullFilePath = path + filename;
            string fullXmlPath = path + xmlName;
            Console.WriteLine(path);
            AssemblyMetadata assemblyMetaData = DataService.LoadAssembly(fullFilePath);
            ISerialize xmlSerialize = new XmlSerialize();
            xmlSerialize.Save(AssemblyMapper.MapToDTGModel(assemblyMetaData), fullXmlPath);
            AssemblyMetadata assemblyMetadata2 = AssemblyMapper.MapToModel(xmlSerialize.Read(fullXmlPath));
            Console.WriteLine(assemblyMetaData.Name);
            Console.WriteLine(assemblyMetadata2.Name);
            Assert.AreEqual(assemblyMetaData.Name, assemblyMetadata2.Name);
        }
    }
}
