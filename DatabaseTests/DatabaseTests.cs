using System;
using System.IO;
using System.Linq;
using Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatabaseTests
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void ConnectToDatabase()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string root = "DatabaseTests";
            while (!(path.Substring(path.Length - root.Length) == root))
            {
                Console.WriteLine(path);
                path = path.Remove(path.Length - 1);
            }
            path += "\\Database.mdf";
            string a = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ";
            string b = @"; Integrated Security = True; Connect Timeout = 30";
            DatabaseModelContext db = new DatabaseModelContext(a + path + b);
        }

        [TestMethod]
        public void AssemblyDatabaseTest()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string root = "DatabaseTests";
            while (!(path.Substring(path.Length - root.Length) == root))
            {
                Console.WriteLine(path);
                path = path.Remove(path.Length - 1);
            }
            path += "\\Database.mdf";
            string a = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ";
            string b = @"; Integrated Security = True; Connect Timeout = 30";
            DatabaseModelContext db = new DatabaseModelContext(a + path + b);
            db.Assemblies.Add(new Database.Model.DatabaseAssemblyMetadata());
            Assert.IsNotNull(db.Assemblies.ToList());
            }

        [TestMethod]
        public void NamespaceDatabaseTest()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string root = "DatabaseTests";
            while (!(path.Substring(path.Length - root.Length) == root))
            {
                Console.WriteLine(path);
                path = path.Remove(path.Length - 1);
            }
            path += "\\Database.mdf";
            string a = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ";
            string b = @"; Integrated Security = True; Connect Timeout = 30";
            DatabaseModelContext db = new DatabaseModelContext(a + path + b);
            db.Namespaces.Add(new Database.Model.DatabaseNamespaceMetadata());
            Assert.IsNotNull(db.Namespaces.ToList());
        }

        [TestMethod]
        public void MethodsDatabaseTest()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string root = "DatabaseTests";
            while (!(path.Substring(path.Length - root.Length) == root))
            {
                Console.WriteLine(path);
                path = path.Remove(path.Length - 1);
            }
            path += "\\Database.mdf";
            string a = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ";
            string b = @"; Integrated Security = True; Connect Timeout = 30";
            DatabaseModelContext db = new DatabaseModelContext(a + path + b);
            db.Methods.Add(new Database.Model.DatabaseMethodMetadata());
            Assert.IsNotNull(db.Methods.ToList());
        }

        [TestMethod]
        public void ProprertiesDatabaseTest()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string root = "DatabaseTests";
            while (!(path.Substring(path.Length - root.Length) == root))
            {
                Console.WriteLine(path);
                path = path.Remove(path.Length - 1);
            }
            path += "\\Database.mdf";
            string a = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ";
            string b = @"; Integrated Security = True; Connect Timeout = 30";
            DatabaseModelContext db = new DatabaseModelContext(a + path + b);
            db.Properties.Add(new Database.Model.DatabasePropertyMetadata());
            Assert.IsNotNull(db.Properties.ToList());
        }

        [TestMethod]
        public void ParametersDatabaseTest()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string root = "DatabaseTests";
            while (!(path.Substring(path.Length - root.Length) == root))
            {
                Console.WriteLine(path);
                path = path.Remove(path.Length - 1);
            }
            path += "\\Database.mdf";
            string a = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ";
            string b = @"; Integrated Security = True; Connect Timeout = 30";
            DatabaseModelContext db = new DatabaseModelContext(a + path + b);
            db.Parameters.Add(new Database.Model.DatabaseParameterMetadata());
            Assert.IsNotNull(db.Parameters.ToList());
        }

        [TestMethod]
        public void TypesDatabaseTest()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string root = "DatabaseTests";
            while (!(path.Substring(path.Length - root.Length) == root))
            {
                Console.WriteLine(path);
                path = path.Remove(path.Length - 1);
            }
            path += "\\Database.mdf";
            string a = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ";
            string b = @"; Integrated Security = True; Connect Timeout = 30";
            DatabaseModelContext db = new DatabaseModelContext(a + path + b);
            db.Types.Add(new Database.Model.DatabaseTypeMetadata());
            Assert.IsNotNull(db.Types.ToList());
        }
    }
}
