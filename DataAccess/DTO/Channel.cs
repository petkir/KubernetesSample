using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.DTO
{
   public class Channel: BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ChannelId { get; set; }

        public ChannelSystem ChannelSystem { get;  }
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        public FlowType FlowType { get; set; }

    }

    public enum FlowType
    {
        In,
        Out
    }
}
