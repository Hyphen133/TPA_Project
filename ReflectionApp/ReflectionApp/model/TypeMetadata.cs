using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ReflectionApp.model
{
    class TypeMetadata
    {
        private string name;
        private List<PropertyMetadata> properties;
        private List<MethodMetadata> methods;

        private static Dictionary<Type, TypeMetadata> createdTypesDictonary;

        public TypeMetadata()
        {
            Properties = new List<PropertyMetadata>();
            Methods = new List<MethodMetadata>();
        }

        
        public static TypeMetadata CreateReferenceTypeMetadata(Type type)
        {
            //Creating properties
            PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            List<PropertyMetadata> propertyMetadatas = PropertyMetadata.CreateProperties(propertyInfos, createdTypesDictonary);

            //Creating methods
            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            List<MethodMetadata> methods = MethodMetadata.CreateMethods(methodInfos,createdTypesDictonary);
            

            //Filling type
            TypeMetadata typeMetadata = new TypeMetadata();
            typeMetadata.Name = type.Name;
            typeMetadata.Properties = propertyMetadatas;
            typeMetadata.Methods = methods;

            return typeMetadata;
        }
        




        public string Name { get => name; set => name = value; }
        public List<PropertyMetadata> Properties { get => properties; set => properties = value; }
        public static Dictionary<Type, TypeMetadata> CreatedTypes { get => createdTypesDictonary; set => createdTypesDictonary = value; }
        internal List<MethodMetadata> Methods { get => methods; set => methods = value; }
    }
}
