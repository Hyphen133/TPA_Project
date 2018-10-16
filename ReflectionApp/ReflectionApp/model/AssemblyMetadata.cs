using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ReflectionApp.model
{
    class AssemblyMetadata
    {
        private string name;
        private List<NamespaceMetadata> namespaces;

        public string Name { get => name; set => name = value; }
        public List<NamespaceMetadata> Namespaces { get => namespaces; set => namespaces = value; }

        public AssemblyMetadata(Assembly assembly)
        {
            this.Namespaces = new List<NamespaceMetadata>();

            this.Name = assembly.GetName().Name;
            Type[] types = assembly.GetTypes();
            //IEnumerable<string> namespaces = (from type in types select type.Namespace).Distinct();
            var namespaces = (from type in types select new { namespaceName = type.Namespace, type = type });

            Dictionary<string, List<Type>> namespaceTypeDictonary = new Dictionary<string, List<Type>>();

            foreach (var namespaceName in ((from n in namespaces select n.namespaceName).Distinct()))
            {
                namespaceTypeDictonary[namespaceName] = new List<Type>();
            }

            foreach (var namespaceType in namespaces)
            {
                namespaceTypeDictonary[namespaceType.namespaceName].Add(namespaceType.type);
            }


            //Creating namespaces
            foreach (string namespaceName in namespaceTypeDictonary.Keys)
            {
                this.Namespaces.Add(new NamespaceMetadata(namespaceName, namespaceTypeDictonary[namespaceName]));
            }

        }
    }
}
