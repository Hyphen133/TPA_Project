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

        private static Dictionary<Type, TypeMetadata> createdTypesDictonary;

        public TypeMetadata()
        {
            Properties = new List<PropertyMetadata>();
        }

        
        public static TypeMetadata CreateTypeMetadata(Type type)
        {
            PropertyInfo[] propertyInfos = type.GetProperties();
            List<PropertyMetadata> propertyMetadatas = PropertyMetadata.MakeProperties(propertyInfos, createdTypesDictonary);

            TypeMetadata typeMetadata = new TypeMetadata();
            typeMetadata.Name = type.Name;
            typeMetadata.Properties = propertyMetadatas;

            return typeMetadata;
        }





        public string Name { get => name; set => name = value; }
        public List<PropertyMetadata> Properties { get => properties; set => properties = value; }
        public static Dictionary<Type, TypeMetadata> CreatedTypes { get => createdTypesDictonary; set => createdTypesDictonary = value; }
    }
}
