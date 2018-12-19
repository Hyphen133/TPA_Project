using Model.Model;
using Model.Tracing;
using System.ComponentModel.Composition;
using System.Reflection;

namespace Model.Services
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
