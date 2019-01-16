using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Database.Model
{
    [Table("Assemblies")]
    public class DatabaseAssemblyMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssemblyID { get; set; }

        [NotMapped]
        public IEnumerable<DatabaseNamespaceMetadata> Namespaces { get; set; }
        public List<DatabaseNamespaceMetadata> NamespacesL { get; set; }
        public string Name { get; set; }

        public void SetValues()
        {
            NamespacesL = Namespaces.ToList();
            foreach (var n in NamespacesL)
            {
                n.SetValues();
            }
        }
    }
}
