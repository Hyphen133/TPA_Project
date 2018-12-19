using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel;

namespace Tests
{
    [TestClass]
    public class WPFViewModelButtonTest
    {
        private MyViewModel myViewModel;

        [TestInitialize]
        public void Initialize()
        {
            myViewModel = new MyViewModel(null);
        }

        [TestMethod]
        public void ViewModelBrowseButtonTest_IfEverythinIsOk_ShouldBeOk()
        {
            Assert.IsTrue(myViewModel.Click_Browse.CanExecute(null));
        }

        [TestMethod]
        public void ViewModelLoadDLLButtonTest_IfEverythinIsOk_ShouldBeOk()
        {
            Assert.IsTrue(myViewModel.Click_Button.CanExecute(null));
        }
    }
}
