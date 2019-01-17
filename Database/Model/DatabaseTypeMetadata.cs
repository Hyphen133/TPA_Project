using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Database.Model
{
    [Table("Types")]
    public class DatabaseTypeMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeID { get; set; }        
        public string TypeName { get; set; }
        public string NamespaceName { get; set; }
        public DatabaseTypeMetadata BaseType { get; set; }
        [NotMapped]
        public IEnumerable<DatabaseTypeMetadata> GenericArguments { get; set; }
        public List<DatabaseTypeMetadata> GenericArgumentsL { get; set; }
        //public Tuple<AccessLevel, SealedEnum, AbstractEnum> Modifiers { get => m_Modifiers; set => m_Modifiers = value; }
        //public TypeKind TypeKind1 { get => m_TypeKind; set => m_TypeKind = value; }
        public bool IsGenericType { get; set; }
        [NotMapped]
        public IEnumerable<DatabaseTypeMetadata> ImplementedInterfaces { get; set; }
        public List<DatabaseTypeMetadata> ImplementedInterfacesL { get; set; }
        [NotMapped]
        public IEnumerable<DatabaseTypeMetadata> NestedTypes { get; set; }
        public List<DatabaseTypeMetadata> NestedTypesL { get; set; }
        [NotMapped]
        public IEnumerable<DatabasePropertyMetadata> Properties { get; set; }
        public List<DatabasePropertyMetadata> PropertiesL { get; set; }
        public DatabaseTypeMetadata DeclaringType { get; set; }
        [NotMapped]
        public IEnumerable<DatabaseMethodMetadata> Methods { get; set; }
        public List<DatabaseMethodMetadata> MethodsL { get; set; }
        [NotMapped]
        public IEnumerable<DatabaseMethodMetadata> Constructors { get; set; }
        public List<DatabaseMethodMetadata> ConstructorsL { get; set; }

        public void SetValue()
        {
            if (GenericArguments == null)
            {
                GenericArgumentsL = null;
            }
            else
            {
                GenericArgumentsL = GenericArguments.ToList();
                foreach (var i in GenericArgumentsL)
                {
                    i.SetValue();
                }
            }

            ImplementedInterfacesL = ImplementedInterfaces.ToList();
            foreach (var i in ImplementedInterfacesL)
            {
                i.SetValue();
            }

            NestedTypesL = NestedTypes.ToList();
            foreach (var i in NestedTypesL)
            {
                i.SetValue();
            }

            PropertiesL = Properties.ToList();

            MethodsL = Methods.ToList();
            foreach (var i in MethodsL)
            {
                i.SetValue();
            }

            ConstructorsL = Constructors.ToList();
            foreach (var i in ConstructorsL)
            {
                i.SetValue();
            }
        }
    }
}
