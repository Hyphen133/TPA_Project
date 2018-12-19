using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataContract
    {
        public AssemblyMetadata assemblyMetadata;
        public Dictionary<string, TypeMetadata> typeDictionary;
        public Dictionary<string, MethodMetadata> methodDictionary;
        public Dictionary<string, DataNamespaceMetadata> namespaceDictionary;
        public Dictionary<string, PropertyMetadata> propertyDictionary;
        public Dictionary<string, ParameterMetadata> parameterDictionary;
    }
}
