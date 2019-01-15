using System.Collections.Generic;
using System.Linq;

namespace Database.Model
{
    public class DatabaseTypeMetadata
    {
        private int m_TypeID;
        private string m_typeName;        
        private string m_NamespaceName;        
        private DatabaseTypeMetadata m_BaseType;        
        private List<DatabaseTypeMetadata> l_GenericArguments;
        private IEnumerable<DatabaseTypeMetadata> m_GenericArguments;
        //private Tuple<AccessLevel, SealedEnum, AbstractEnum> m_Modifiers;
        //private TypeKind m_TypeKind;        
        private bool m_isGenericType;        
        private List<DatabaseTypeMetadata> l_ImplementedInterfaces;
        private IEnumerable<DatabaseTypeMetadata> m_ImplementedInterfaces;        
        private List<DatabaseTypeMetadata> l_NestedTypes;
        private IEnumerable<DatabaseTypeMetadata> m_NestedTypes;        
        private List<DatabasePropertyMetadata> l_Properties;
        private IEnumerable<DatabasePropertyMetadata> m_Properties;        
        private DatabaseTypeMetadata m_DeclaringType;        
        private List<DatabaseMethodMetadata> l_Methods;
        private IEnumerable<DatabaseMethodMetadata> m_Methods;        
        private List<DatabaseMethodMetadata> l_Constructors;
        private IEnumerable<DatabaseMethodMetadata> m_Constructors;

        public int TypeID { get => m_TypeID; set => m_TypeID = value; }
        public string TypeName { get => m_typeName; set => m_typeName = value; }
        public string NamespaceName { get => m_NamespaceName; set => m_NamespaceName = value; }
        public DatabaseTypeMetadata BaseType { get => m_BaseType; set => m_BaseType = value; }
        public IEnumerable<DatabaseTypeMetadata> GenericArguments { get => m_GenericArguments; set => m_GenericArguments = value; }
        public List<DatabaseTypeMetadata> GenericArgumentsL { get => l_GenericArguments; set => l_GenericArguments = value; }
        //public Tuple<AccessLevel, SealedEnum, AbstractEnum> Modifiers { get => m_Modifiers; set => m_Modifiers = value; }
        //public TypeKind TypeKind1 { get => m_TypeKind; set => m_TypeKind = value; }
        public bool IsGenericType { get => m_isGenericType; set => m_isGenericType = value; }
        public IEnumerable<DatabaseTypeMetadata> ImplementedInterfaces { get => m_ImplementedInterfaces; set => m_ImplementedInterfaces = value; }
        public List<DatabaseTypeMetadata> ImplementedInterfacesL { get => l_ImplementedInterfaces; set => l_ImplementedInterfaces = value; }
        public IEnumerable<DatabaseTypeMetadata> NestedTypes { get => m_NestedTypes; set => m_NestedTypes = value; }
        public List<DatabaseTypeMetadata> NestedTypesL { get => l_NestedTypes; set => l_NestedTypes = value; }
        public IEnumerable<DatabasePropertyMetadata> Properties { get => m_Properties; set => m_Properties = value; }
        public List<DatabasePropertyMetadata> PropertiesL { get => l_Properties; set => l_Properties = value; }
        public DatabaseTypeMetadata DeclaringType { get => m_DeclaringType; set => m_DeclaringType = value; }
        public IEnumerable<DatabaseMethodMetadata> Methods { get => m_Methods; set => m_Methods = value; }
        public List<DatabaseMethodMetadata> MethodsL { get => l_Methods; set => l_Methods = value; }
        public IEnumerable<DatabaseMethodMetadata> Constructors { get => m_Constructors; set => m_Constructors = value; }
        public List<DatabaseMethodMetadata> ConstructorsL { get => l_Constructors; set => l_Constructors = value; }

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
