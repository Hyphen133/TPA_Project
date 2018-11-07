using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TPA.Reflection.Model;
using TPAv2.Services;

namespace Tests
{
    [TestClass]
    public class TracingTest
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod1()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string root = "TPA_Project";
            while (!(path.Substring(path.Length - root.Length) == root))
            {
                path = path.Remove(path.Length - 1);
                Console.WriteLine(path);
            }
            Console.WriteLine(path);
            string filename = "\\Tests\\TPA.ApplicationArchitecture.dll";
            string xmlName = "\\Tests\\test.xml";
            string fullFilePath = path + filename;
            string fullXmlPath = path + xmlName;
            Console.WriteLine(fullFilePath);
            AssemblyMetadata assemblyMetaData = DataService.LoadAssembly(fullFilePath);
            XmlSerialize xmlSerialize = new XmlSerialize(new FileTraceSource("hahaherroransko"));
        }
    }
}
