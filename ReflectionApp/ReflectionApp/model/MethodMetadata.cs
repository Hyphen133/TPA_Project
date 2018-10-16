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
        private string returnTypeName;

        public static List<MethodMetadata> CreateMethods(MethodInfo[] methodInfos, Dictionary<Type, TypeMetadata> createdTypesDictonary)
        {
            List<MethodMetadata> methodMetadatas = new List<MethodMetadata>();
            foreach (MethodInfo methodInfo in methodInfos)
            {
                MethodMetadata methodMetadata = new MethodMetadata();


                methodMetadata.Name = methodInfo.Name;

                //Checking if return type was already created
                if(createdTypesDictonary.ContainsKey(methodInfo.ReturnType))
                {
                    methodMetadata.ReturnType = createdTypesDictonary[methodInfo.ReturnType];
                }
                else
                {
                    //Check if not better to make null
                    TypeMetadata typeMetadata = new TypeMetadata();
                    createdTypesDictonary[methodInfo.ReturnType] = typeMetadata;
                    typeMetadata = TypeMetadata.CreateReferenceTypeMetadata(methodInfo.ReturnType);

                    methodMetadata.ReturnType = typeMetadata;
                    
                }
                //Adding parameters TODO!!!

                //Returning Name correctly but not TypeMetadata?
                methodMetadata.ReturnTypeName = methodInfo.ReturnType.Name;
                methodMetadatas.Add(methodMetadata);
            }

            return methodMetadatas;
        }

        public MethodMetadata()
        {
        }

       

        public string Name { get => name; set => name = value; }
        public TypeMetadata ReturnType { get => returnType; set => returnType = value; }
        public string ReturnTypeName { get => returnTypeName; set => returnTypeName = value; }
    }
}
