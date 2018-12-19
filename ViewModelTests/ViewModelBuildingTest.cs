using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using ViewModel.TreeView;

namespace ViewModelTests
{
    [TestClass]
    public class ViewModelBuildingTest
    {
        
        [TestMethod]
        public void TreeViewItemBuildingTest_WhenChildrenCountIsSetTo3_ShouldBe3()
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
            BaseTreeViewItem rootItem = new AssemblyTreeViewItem();
            rootItem.Children.Clear();
            rootItem.Children.Add(null);
            rootItem.Children.Add(null);
            rootItem.Children.Add(null);
            Assert.AreEqual(rootItem.Children.Count, 3);

        }
    }
}
