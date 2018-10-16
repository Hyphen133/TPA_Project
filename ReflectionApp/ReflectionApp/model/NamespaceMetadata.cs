using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionApp.model
{
    class NamespaceMetadata
    {
        private string name;
        private List<TypeMetadata> types;



        public NamespaceMetadata(string name, List<Type> types)
        {
            this.Name = name;
            this.types = new List<TypeMetadata>();

            foreach (Type type in types)
            {
                Types.Add(TypeMetadata.CreateTypeMetadata(type));
            }


        }

        public string Name { get => name; set => name = value; }
        public List<TypeMetadata> Types { get => types; set => types = value; }
    }
}
