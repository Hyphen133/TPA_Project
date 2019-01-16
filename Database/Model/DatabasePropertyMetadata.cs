﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Model
{
    [Table("Properties")]
    public class DatabasePropertyMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PropertyID { get; set; }
        public string Name { get; set; }
        //[Column("PropertyType")]
        [NotMapped]
        public DatabaseTypeMetadata TypeMetadata { get; set; }
        //public int TypeID { get; set; }
    }
}
