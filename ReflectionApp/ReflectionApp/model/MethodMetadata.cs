using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ReflectionApp.model
{
    class MethodMetadata
    {
        private string name;
        private TypeMetadata returnType;
        private List<ParameterMetadata> parameters;

        public static List<MethodMetadata> CreateMethods(MethodInfo[] methodInfos, Dictionary<Type, TypeMetadata> createdTypesDictonary)
        {
            List<MethodMetadata> methodMetadatas = new List<MethodMetadata>();
            foreach (MethodInfo methodInfo in methodInfos)
            {
                MethodMetadata methodMetadata = new MethodMetadata();


                methodMetadata.Name = methodInfo.Name;

                //Adding return type
                if(!createdTypesDictonary.ContainsKey(methodInfo.ReturnType))
                {
                    TypeMetadata typeMetadata = new TypeMetadata();
                    createdTypesDictonary[methodInfo.ReturnType] = typeMetadata;
                    createdTypesDictonary[methodInfo.ReturnType] = TypeMetadata.CreateReferenceTypeMetadata(methodInfo.ReturnType);
                }
                methodMetadata.ReturnType = createdTypesDictonary[methodInfo.ReturnType];

                //Adding parameters
                ParameterInfo[] parameterInfos = methodInfo.GetParameters();
                methodMetadata.Parameters = ParameterMetadata.CreateParameters(parameterInfos, createdTypesDictonary);


                //Returning Name correctly but not TypeMetadata?
                methodMetadatas.Add(methodMetadata);
            }

            return methodMetadatas;
        }

        public MethodMetadata()
        {
        }

       

        public string Name { get => name; set => name = value; }
        public TypeMetadata ReturnType { get => returnType; set => returnType = value; }
        internal List<ParameterMetadata> Parameters { get => parameters; set => parameters = value; }
    }
}
