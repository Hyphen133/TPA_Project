using ReflectionApp.model;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ReflectionApp
{
    class Program
    {
        static readonly string assemblyFile = @"C:\Users\hyphe\Desktop\Projects\PTG\TPA_Project\ReflectionApp\ReflectionApp\TPA.ApplicationArchitecture.dll";

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

            foreach (var type in assemblyMetadata.Namespaces[2].Types)
            {
                Console.WriteLine("----" + type.Name);
                foreach (var property in type.Properties)
                {
                    Console.WriteLine(property.Name);
                }
            }


            Console.ReadKey();
        }
    }
}
