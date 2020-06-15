using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.DTO
{
    public class ChannelMessage: BaseEntity
    {
        [Key]
        public Guid TransactionID { get; set; }
        public Guid? ParentTransactionID { get; set; }


        public string MessageBody { get; set; }

        public DateTimeOffset ReceivedDate { get; set; }

        public ProcessingStatus ProcessingStatus { get; set; }

        public Guid SourceChannelID { get; set; }
        public Guid? TargetChannelID { get; set; }



        [ForeignKey("SourceChannelID")]
        public ChannelSystem SourceChannel { get; set; }
        [ForeignKey("TargetChannelID")]
        public ChannelSystem? TargetChannel { get; set; }

        [ForeignKey("ParentTransactionID")]
        public ChannelMessage ParentTransaction { get; set; }

        public ICollection<LogEntry> Logs { get; } = new List<LogEntry>();
    }

    public enum ProcessingStatus
    {
        Received,
        Processing,
        Canceled,
        Error
    }
}
