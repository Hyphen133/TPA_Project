using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ReflectionApp.model
{
    class PropertyMetadata
    {
        private string name;
        private TypeMetadata type;

        
        public static List<PropertyMetadata> MakeProperties(PropertyInfo[] propertyInfos, Dictionary<Type, TypeMetadata> createdTypesDictonary)
        {
            List<PropertyMetadata> propertyMetadatas = new List<PropertyMetadata>();
            foreach (var item in propertyInfos)
	        {
                if(!createdTypesDictonary.ContainsKey(item.PropertyType))
                {
                    TypeMetadata type = new TypeMetadata();
                    createdTypesDictonary[item.PropertyType] = type;
                    type = TypeMetadata.CreateReferenceTypeMetadata(item.PropertyType);
                }
                propertyMetadatas.Add(new PropertyMetadata(item.PropertyType.Name, type));
            }

            return propertyMetadatas;
        }

        public PropertyMetadata(string name, TypeMetadata typeMetadata)
        {
            this.Name = name;
            this.Type = typeMetadata;
        }

        public string Name { get => name; set => name = value; }
        public TypeMetadata Type { get => type; set => type = value; }
    }
}
