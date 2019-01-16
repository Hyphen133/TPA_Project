using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Database.Model
{
    [Table("Namespaces")]
    public class DatabaseNamespaceMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NamespaceID { get; set; }
        public string NamespaceName { get; set; }
        [NotMapped]
        public IEnumerable<DatabaseTypeMetadata> Types { get; set; }
        public List<DatabaseTypeMetadata> TypesL { get; set; }

        public void SetValues()
        {
            TypesL = Types.ToList();
            foreach (var i in TypesL)
            {
                i.SetValue();
            }
        }
    }
}
