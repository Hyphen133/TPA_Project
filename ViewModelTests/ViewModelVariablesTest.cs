using System;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel;
using ViewModel.TreeView;

namespace ViewModelTests
{
    [TestClass]
    public class ViewModelVariablesTest
    {
        private MyViewModel myViewModel;

        [TestInitialize]
        public void Initialize()
        {
            
        }

        /*[TestMethod]
        public void PathVariable_WhenIsSetToOtherValue_ShouldChange()
        {
            myViewModel = new MyViewModel(null);
            string before = "before";
            string after = "after";

            myViewModel.PathVariable = before;
            Assert.AreEqual(before, myViewModel.PathVariable);

            myViewModel.PathVariable = after;
            Assert.AreEqual(after, myViewModel.PathVariable);
        }*/

        /*[TestMethod]
        public void HierarchicalAreas_WhenIsSetToOtherValue_ShouldChange()
        {
            ObservableCollection<BaseTreeViewItem> before = new ObservableCollection<BaseTreeViewItem>();
            before.Add(new AssemblyTreeViewItem());
            before.Add(new AssemblyTreeViewItem());
            ObservableCollection<BaseTreeViewItem> after = new ObservableCollection<BaseTreeViewItem>();
            after.Add(new AssemblyTreeViewItem());

            myViewModel.HierarchicalAreas = before;
            Assert.AreEqual(before.Count, myViewModel.HierarchicalAreas.Count);

            myViewModel.HierarchicalAreas = after;
            Assert.AreEqual(after.Count, myViewModel.HierarchicalAreas.Count);
        }*/
    }
}
