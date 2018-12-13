using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Data
{
    [DataContract(IsReference = true)]
    public class MethodMetadata
    {
        [DataMember]
        private string m_Name;
        [DataMember]
        private IEnumerable<TypeMetadata> m_GenericArguments;
        [DataMember]
        private Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum> m_Modifiers;
        [DataMember]
        private TypeMetadata m_ReturnType;
        [DataMember]
        private bool m_Extension;
        [DataMember]
        private IEnumerable<ParameterMetadata> m_Parameters;

        public string Name { get => m_Name; set => m_Name = value; }
        public IEnumerable<TypeMetadata> GenericArguments { get => m_GenericArguments; set => m_GenericArguments = value; }
        public Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum> Modifiers { get => m_Modifiers; set => m_Modifiers = value; }
        public TypeMetadata ReturnType { get => m_ReturnType; set => m_ReturnType = value; }
        public bool Extension { get => m_Extension; set => m_Extension = value; }
        public IEnumerable<ParameterMetadata> Parameters { get => m_Parameters; set => m_Parameters = value; }
    }
}