using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Model
{
    [Table("Parameters")]
    public class DatabaseParameterMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParameterID { get; set; }      
        public string Name { get; set; }
        public DatabaseTypeMetadata TypeMetadata { get; set; }
    }
}
