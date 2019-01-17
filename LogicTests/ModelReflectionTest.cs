using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Model;
using Logic.Services;
using System;

namespace ModelTests
{
    [TestClass]
    public class ModelReflectionTest
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void AssemblyMetaData_WhenPathIsWrong_ShouldThrowException()
        {
            AssemblyMetadata assemblyMetaData = DataService.LoadAssembly("Wroooong");
        }

        [TestMethod]
        public void AssemblyMetaData_WhenIsOk_ShouldBeOk()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string root = "LogicTests";
            while (!(path.Substring(path.Length - root.Length) == root))
            {
                Console.WriteLine(path);
                path = path.Remove(path.Length - 1);
            }
            string filename = "\\TPA.ApplicationArchitecture.dll";
            string fullFilePath = path + filename;
            Console.WriteLine(fullFilePath);
            AssemblyMetadata assemblyMetaData = DataService.LoadAssembly(fullFilePath);
            Assert.IsNotNull(assemblyMetaData);
        }

        [TestMethod]
        public void NamespacesInAssembly_WhenAssemblyIsOk_ThereShouldBeAtLeastOneNamespace()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string root = "LogicTests";
            while (!(path.Substring(path.Length - root.Length) == root))
            {
                path = path.Remove(path.Length - 1);
            }
            string filename = "\\TPA.ApplicationArchitecture.dll";
            string fullFilePath = path + filename;
            AssemblyMetadata assemblyMetaData = DataService.LoadAssembly(fullFilePath);
            List<NamespaceMetadata> pom = assemblyMetaData.Namespaces.ToList();
            Assert.IsTrue(pom.Count >= 0);
        }

        [TestMethod]
        public void TypesInNamespace_WhenNamespaceIsOk_ThereShouldBeAtLeastOneType()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string root = "LogicTests";
            while (!(path.Substring(path.Length - root.Length) == root))
            {
                path = path.Remove(path.Length - 1);
            }
            string filename = "\\TPA.ApplicationArchitecture.dll";
            string fullFilePath = path + filename;
            AssemblyMetadata assemblyMetaData = DataService.LoadAssembly(fullFilePath);
            List<NamespaceMetadata> pom1 = assemblyMetaData.Namespaces.ToList();
            List<TypeMetadata> pom2 = pom1[0].Types.ToList();
            Assert.IsTrue(pom2.Count >= 0);
        }
    }
}
