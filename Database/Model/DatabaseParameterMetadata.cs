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
        private string m_Name;
        private DatabaseTypeMetadata m_TypeMetadata;
        
        public string Name { get => m_Name; set => m_Name = value; }
        public DatabaseTypeMetadata TypeMetadata { get => m_TypeMetadata; set => m_TypeMetadata = value; }
    }
}
