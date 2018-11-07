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
        [ExpectedException(typeof(FileNotFoundException))]
        public void TracingTest_WhenPathIsWrong_ShouldThrowexception()
        {
            string wrongPath = "IAmWrongPath";
            FileTraceSource fileTraceSource = new FileTraceSource(wrongPath);
        }
    }
}
