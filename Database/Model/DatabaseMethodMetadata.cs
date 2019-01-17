using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Database.Model
{
    [Table("Methods")]
    public class DatabaseMethodMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MethodID { get; set; }        
        [Column("Name")]
        public string Name { get; set; }
        [NotMapped]
        public IEnumerable<DatabaseTypeMetadata> GenericArguments { get; set; }
        [Column("GenericArguments")]
        public List<DatabaseTypeMetadata> GenericArgumentsL { get; set; }
        [Column("ReturnType")]
        public DatabaseTypeMetadata ReturnType { get; set; }
        [NotMapped]
        public IEnumerable<DatabaseParameterMetadata> Parameters { get; set; }
        [Column("Parameters")]
        public List<DatabaseParameterMetadata> ParametersL { get; set; }

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

            ParametersL = Parameters.ToList();
        }
    }
}
