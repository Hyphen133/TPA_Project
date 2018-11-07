﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewWPF;

namespace Tests
{
    [TestClass]
    public class WPFViewModelButtonTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ViewForWPF vm = new ViewForWPF();
            Assert.IsTrue(vm.Click_Browse.CanExecute(null));
            Assert.IsTrue(vm.Click_Button.CanExecute(null));
        }
    }
}
