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

        //public PropertyMetadata(string name, Type type)
        //{
        //    this.Name = name;
        //    this.Type = new TypeMetadata(type);
        //}
       
        public PropertyMetadata(string name, TypeMetadata typeMetadata)
        {
            this.Name = name;
            this.Type = typeMetadata;
        }

        public string Name { get => name; set => name = value; }
        public TypeMetadata Type { get => type; set => type = value; }
    }
}
