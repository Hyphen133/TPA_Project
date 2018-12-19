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
            myViewModel = new MyViewModel(null);
        }

        [TestMethod]
        public void PathVariable_WhenIsSetToOtherValue_ShouldChange()
        {
            string before = "before";
            string after = "after";

            myViewModel.PathVariable = before;
            Assert.AreEqual(before, myViewModel.PathVariable);

            myViewModel.PathVariable = after;
            Assert.AreEqual(after, myViewModel.PathVariable);
        }

        [TestMethod]
        public void HierarchicalAreas_WhenIsSetToOtherValue_ShouldChange()
        {
            ObservableCollection<BaseTreeViewItem> before = new ObservableCollection<BaseTreeViewItem>();
            before.Add(null);
            before.Add(null);
            ObservableCollection<BaseTreeViewItem> after = new ObservableCollection<BaseTreeViewItem>();
            after.Add(null);

            myViewModel.HierarchicalAreas = before;
            Assert.AreEqual(before.Count, myViewModel.HierarchicalAreas.Count);

            myViewModel.HierarchicalAreas = after;
            Assert.AreEqual(after.Count, myViewModel.HierarchicalAreas.Count);
        }
    }
}
