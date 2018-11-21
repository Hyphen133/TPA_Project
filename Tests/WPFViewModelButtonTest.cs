using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel;

namespace Tests
{
    [TestClass]
    public class WPFViewModelButtonTest
    {
        [TestMethod]
        public void WPFViewModelButtonTest_IfEverythinIsOk_ShouldBeOk()
        {
            MyViewModel vm = new MyViewModel(null);
            Assert.IsTrue(vm.Click_Browse.CanExecute(null));
            Assert.IsTrue(vm.Click_Button.CanExecute(null));
        }
    }
}
