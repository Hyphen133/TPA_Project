using Model;
using System;
using System.IO;
using System.Reflection;

namespace TPAv2.Services
{
    public class DataService
    {
        public static AssemblyMetadata LoadAssembly(string PathValue)
        {
            Assembly assembly = Assembly.LoadFrom(PathValue);
            return new AssemblyMetadata(assembly);
        }
    }
}
