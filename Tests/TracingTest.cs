using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Model.Tracing;
using Model.MEF;

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
            ITraceSource tracing = Mef.Container.GetExportedValue<ITraceSource>();
            ((FileTraceSource)tracing).Filepath = wrongPath;
        }
    }
}
