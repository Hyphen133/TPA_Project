using System;
using System.IO;
using System.Reflection;
using TPA.Reflection.Model;

namespace TPA
{
    class Program
    {

        static readonly string assemblyFile = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"TPA.ApplicationArchitecture.dll");

        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom(assemblyFile);
            AssemblyMetadata assemblyMetadata = new AssemblyMetadata(assembly);


            foreach (var ns in assemblyMetadata.Namespaces)
            {
                Console.WriteLine("<<<<<<" + ns.NamespaceName);
                foreach (var type in ns.Types)
                {
                    Console.WriteLine("----" + type.TypeName);
                    foreach (var property in type.Properties)
                    {
                        Console.WriteLine(property.Name);
                        
                    }
                    foreach (var method in type.Methods)
                    {
                        Console.WriteLine(method.ReturnType.TypeName + " " + method.Name);
                    }
                }
            }



            Console.ReadKey();
        }
    }
}
