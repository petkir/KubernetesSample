using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text;

namespace DataAccess.DTO
{
    public class Contact: BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ID { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string LastName { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Email { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Tel { get; set; }

        public Dictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
    }
}
