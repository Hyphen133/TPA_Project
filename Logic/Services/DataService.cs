using Logic.Model;
using System.Reflection;

namespace Logic.Services
{
    public class DataService
    {
        public static AssemblyMetadata LoadAssembly(string PathValue)
        {
            Assembly assembly = Assembly.ReflectionOnlyLoadFrom(PathValue);
            return new AssemblyMetadata(assembly);
        }
    }
}
