using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ReflectionApp.model
{
    class ParameterMetadata
    {
        private string name;
        private TypeMetadata typeMetadata;

        public static List<ParameterMetadata> CreateParameters(ParameterInfo[] parameterInfos, Dictionary<Type, TypeMetadata> createdTypesDictonary)
        {
            List<ParameterMetadata> parameterMetadatas = new List<ParameterMetadata>();

            foreach (ParameterInfo parameterInfo in parameterInfos)
            {
                if (createdTypesDictonary.ContainsKey(parameterInfo.ParameterType))
                {
                    parameterMetadatas.Add(new ParameterMetadata(parameterInfo.Name, createdTypesDictonary[parameterInfo.ParameterType]));
                }
                else
                {
                    TypeMetadata type = new TypeMetadata();
                    createdTypesDictonary[parameterInfo.ParameterType] = type;
                    createdTypesDictonary[parameterInfo.ParameterType] = TypeMetadata.CreateReferenceTypeMetadata(parameterInfo.ParameterType);
                    parameterMetadatas.Add(new ParameterMetadata(parameterInfo.Name, createdTypesDictonary[parameterInfo.ParameterType]));

                }
            }

            return parameterMetadatas;
        }

        public ParameterMetadata(string name, TypeMetadata typeMetadata)
        {
            Name = name;
            TypeMetadata = typeMetadata;
        }

        public string Name { get => name; set => name = value; }
        public TypeMetadata TypeMetadata { get => typeMetadata; set => typeMetadata = value; }
    }
}
