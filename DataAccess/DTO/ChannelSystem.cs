using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.DTO
{
  public  class ChannelSystem: BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ID { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }

        public Contact Contact { get; set; }

        public ICollection<Channel> Channels { get; } = new List<Channel>();
    }
}
