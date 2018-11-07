using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP.GraphicalData.TreeView;
using TPAv2.Services;
using TPA.Reflection.Model;
using ViewWPF.TreeView;
using System.IO;

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
            TreeViewItem originalRootItem = ConversionServices.ConvertAssemblyMetadata(assemblyMetadata);
            TreeViewItem rootItem = new TreeViewItem();
            rootItem.Name = originalRootItem.Name;
            rootItem.OriginalItem = originalRootItem;
            rootItem.IsExpanded = true;
            Assert.AreEqual(rootItem.Children.Count, 3);

        }
    }
}
