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

        
        public static List<PropertyMetadata> CreateProperties(PropertyInfo[] propertyInfos, Dictionary<Type, TypeMetadata> createdTypesDictonary)
        {
            List<PropertyMetadata> propertyMetadatas = new List<PropertyMetadata>();
            foreach (PropertyInfo propertyInfo in propertyInfos)
	        {
                PropertyMetadata propertyMetadata = new PropertyMetadata();

                //Name
                propertyMetadata.Name = propertyInfo.Name;

                //Type
                if (!createdTypesDictonary.ContainsKey(propertyInfo.PropertyType))
                {
                    TypeMetadata type = new TypeMetadata();
                    createdTypesDictonary[propertyInfo.PropertyType] = type;
                    createdTypesDictonary[propertyInfo.PropertyType] = TypeMetadata.CreateReferenceTypeMetadata(propertyInfo.PropertyType);
                }
                propertyMetadata.Type = createdTypesDictonary[propertyInfo.PropertyType];

                

                propertyMetadatas.Add(propertyMetadata);
            }

            return propertyMetadatas;
        }

        public PropertyMetadata()
        {
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
