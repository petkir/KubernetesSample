using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.DTO
{
    public class LogEntry: BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ID { get; set; }

        public Guid TransactionID { get; set; }

        public DBLogLevel Level { get; set; }

        public string ServerName { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

      
    }

    public enum DBLogLevel
    {
        Verbose,
        Debug,
        Info,
        Warning,
        Critical,
        Error
    }
}
