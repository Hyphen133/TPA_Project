using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPAv2.Services;
using Model;
using System.IO;
using ViewModel.TreeView;

namespace Tests
{
    [TestClass]
    public class TreeViewItemBuildingTest
    {
        
        [TestMethod]
        public void BuildingTest()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string root = "Tests";
            while (!(path.Substring(path.Length - root.Length) == root))
            {
                path = path.Remove(path.Length - 1);
                Console.WriteLine(path);
            }

            Console.WriteLine(path);
            string filename = "\\TPA.ApplicationArchitecture.dll";
            string fullFilePath = path + filename;
            Console.WriteLine(fullFilePath);
            AssemblyMetadata assemblyMetadata = DataService.LoadAssembly(fullFilePath);
            BaseTreeViewItem rootItem = new AssemblyTreeViewItem(assemblyMetadata);
            rootItem.IsExpanded = true;
            Assert.AreEqual(rootItem.Children.Count, 3);

        }
    }
}
