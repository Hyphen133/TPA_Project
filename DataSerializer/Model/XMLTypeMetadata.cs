using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace DataSerializer.Model
{
    [DataContract(IsReference = true)]
    public class XMLTypeMetadata
    {
        [DataMember]
        private string m_typeName;
        [DataMember]
        private string m_NamespaceName;
        [DataMember]
        private XMLTypeMetadata m_BaseType;
        [DataMember]
        private List<XMLTypeMetadata> l_GenericArguments;
        private IEnumerable<XMLTypeMetadata> m_GenericArguments;
        //private Tuple<AccessLevel, SealedEnum, AbstractEnum> m_Modifiers;
        //private TypeKind m_TypeKind;
        [DataMember]
        private bool m_isGenericType;
        [DataMember]
        private List<XMLTypeMetadata> l_ImplementedInterfaces;
        private IEnumerable<XMLTypeMetadata> m_ImplementedInterfaces;
        [DataMember]
        private List<XMLTypeMetadata> l_NestedTypes;
        private IEnumerable<XMLTypeMetadata> m_NestedTypes;
        [DataMember]
        private List<XMLPropertyMetadata> l_Properties;
        private IEnumerable<XMLPropertyMetadata> m_Properties;
        [DataMember]
        private XMLTypeMetadata m_DeclaringType;
        [DataMember]
        private List<XMLMethodMetadata> l_Methods;
        private IEnumerable<XMLMethodMetadata> m_Methods;
        [DataMember]
        private List<XMLMethodMetadata> l_Constructors;
        private IEnumerable<XMLMethodMetadata> m_Constructors;

        public string TypeName { get => m_typeName; set => m_typeName = value; }
        public string NamespaceName { get => m_NamespaceName; set => m_NamespaceName = value; }
        public XMLTypeMetadata BaseType { get => m_BaseType; set => m_BaseType = value; }
        public IEnumerable<XMLTypeMetadata> GenericArguments { get => m_GenericArguments; set => m_GenericArguments = value; }
        //public Tuple<AccessLevel, SealedEnum, AbstractEnum> Modifiers { get => m_Modifiers; set => m_Modifiers = value; }
        //public TypeKind TypeKind1 { get => m_TypeKind; set => m_TypeKind = value; }
        public bool IsGenericType { get => m_isGenericType; set => m_isGenericType = value; }
        public IEnumerable<XMLTypeMetadata> ImplementedInterfaces { get => m_ImplementedInterfaces; set => m_ImplementedInterfaces = value; }
        public IEnumerable<XMLTypeMetadata> NestedTypes { get => m_NestedTypes; set => m_NestedTypes = value; }
        public IEnumerable<XMLPropertyMetadata> Properties { get => m_Properties; set => m_Properties = value; }
        public XMLTypeMetadata DeclaringType { get => m_DeclaringType; set => m_DeclaringType = value; }
        public IEnumerable<XMLMethodMetadata> Methods { get => m_Methods; set => m_Methods = value; }
        public IEnumerable<XMLMethodMetadata> Constructors { get => m_Constructors; set => m_Constructors = value; }

        public void SetValue()
        {
            if (m_GenericArguments == null)
            {
                l_GenericArguments = null;
            }
            else
            {
                l_GenericArguments = m_GenericArguments.ToList();
                foreach (var i in l_GenericArguments)
                {
                    i.SetValue();
                }
            }

            l_ImplementedInterfaces = m_ImplementedInterfaces.ToList();
            foreach (var i in l_ImplementedInterfaces)
            {
                i.SetValue();
            }

            l_NestedTypes = m_NestedTypes.ToList();
            foreach (var i in l_NestedTypes)
            {
                i.SetValue();
            }

            l_Properties = m_Properties.ToList();

            l_Methods = m_Methods.ToList();
            foreach (var i in l_Methods)
            {
                i.SetValue();
            }

            l_Constructors = m_Constructors.ToList();
            foreach (var i in l_Constructors)
            {
                i.SetValue();
            }
        }
    }
}
