using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Model.Tracing;
using Model.MEF;

namespace Tests
{
    [TestClass]
    public class ModelTracingTest
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TracingTest_WhenPathIsWrong_ShouldThrowexception()
        {
            string wrongPath = "IAmWrongPath";
            ITraceSource tracing = Mef.Container.GetExportedValue<ITraceSource>();
            ((FileTraceSource)tracing).Filepath = wrongPath;
        }

        [TestMethod]
        public void TracingTest_WhenPathIsCorrect_ShouldBeOk()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string root = "Tests";
            while (!(path.Substring(path.Length - root.Length) == root))
            {
                path = path.Remove(path.Length - 1);
            }
            string filename = "\\TPA.ApplicationArchitecture.dll";
            string xmlName = "\\test.xml";
            string fullFilePath = path + filename;
            string fullXmlPath = path + xmlName;

            ITraceSource tracing = Mef.Container.GetExportedValue<ITraceSource>();
            ((FileTraceSource)tracing).Filepath = fullFilePath;
        }
    }
}


