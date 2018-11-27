using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serializer;
using TPA.Reflection.Model;
using TPAv2.Services;

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
            Console.WriteLine(fullFilePath);
            AssemblyMetadata assemblyMetaData = DataService.LoadAssembly(fullFilePath);
            ISerialize xmlSerialize = new XmlSerialize(null, fullXmlPath);
            xmlSerialize.Write(assemblyMetaData);
            AssemblyMetadata assemblyMetadata2 = (AssemblyMetadata)xmlSerialize.Read(typeof(AssemblyMetadata));
            Assert.AreEqual(assemblyMetaData.Name, assemblyMetadata2.Name);
        }
    }
}
