using System;
using System.IO;
using System.Reflection;
using TPA.Reflection.Model;

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
