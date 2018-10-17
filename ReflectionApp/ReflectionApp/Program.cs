using ReflectionApp.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ReflectionApp
{
    class Program
    {
        static readonly string assemblyFile = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"TPA.ApplicationArchitecture.dll");

        public static void Main(String[] args)
        {
            //config!!!
            TypeMetadata.CreatedTypes = new Dictionary<Type, TypeMetadata>();
            Assembly assembly = Assembly.LoadFrom(assemblyFile);
            AssemblyMetadata assemblyMetadata = new AssemblyMetadata(assembly);
            Console.WriteLine(assemblyMetadata.Name);
            Console.WriteLine();

            foreach (var nmsp in assemblyMetadata.Namespaces)
            {
                Console.WriteLine(nmsp.Name);
            }
            Console.WriteLine();

            foreach (var type in assemblyMetadata.Namespaces[2].Types)
            {
                Console.WriteLine(type.Name);
            }
            Console.WriteLine();

            foreach (var item in assemblyMetadata.GetType().GetProperties())
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine();

            foreach (var type in assemblyMetadata.Namespaces[0].Types)
            {
                Console.WriteLine("----" + type.Name);
                List<PropertyMetadata> properties = type.Properties;
                foreach (var property in properties)
                {
                    Console.WriteLine(property.Name);
                }
            }

            Console.WriteLine();

            foreach (var type in assemblyMetadata.Namespaces[1].Types)
            {
                Console.WriteLine("----" + type.Name);
                foreach (var property in type.Properties)
                {
                    Console.WriteLine(property.Name);
                }
            }

            Console.WriteLine();

            foreach (var type in assemblyMetadata.Namespaces[2].Types)
            {
                Console.WriteLine("----" + type.Name);
                foreach (var property in type.Properties)
                {
                    Console.WriteLine(property.Name);
                }
            }

            Console.WriteLine();
            Console.WriteLine();


            foreach (var method in assemblyMetadata.Namespaces[1].Types[0].Methods)
            {
                Console.WriteLine(method.Name + "  --  " + method.ReturnType.Name);
            }

            Console.WriteLine();
            

            Console.ReadKey();
        }
    }
}
