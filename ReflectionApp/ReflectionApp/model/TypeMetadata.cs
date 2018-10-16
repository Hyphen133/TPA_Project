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

        private static Dictionary<string, TypeMetadata> createdTypesDictonary;


        public TypeMetadata(Type type)
        {
            createdTypesDictonary[type.FullName] = this;
            Name = type.Name;
            Properties = new List<PropertyMetadata>();
            PropertyInfo[] propertyInfos = type.GetProperties();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                //Key must be with namespace
                if (createdTypesDictonary.ContainsKey(type.GetType().FullName))
                {
                    PropertyMetadata propertyMetadata = new PropertyMetadata(propertyInfo.Name, createdTypesDictonary[type.GetType().FullName]);
                    Properties.Add(propertyMetadata);
                }
                else
                {
                    TypeMetadata typeMetadata = new TypeMetadata(propertyInfo.PropertyType);
              
                    PropertyMetadata propertyMetadata = new PropertyMetadata(propertyInfo.Name, typeMetadata);
                    Properties.Add(propertyMetadata);
                }
            }
        }

     



        public string Name { get => name; set => name = value; }
        public List<PropertyMetadata> Properties { get => properties; set => properties = value; }
        public static Dictionary<string, TypeMetadata> CreatedTypes { get => createdTypesDictonary; set => createdTypesDictonary = value; }
    }
}
