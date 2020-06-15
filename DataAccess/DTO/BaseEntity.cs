using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DTO
{
   public class BaseEntity
    {
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
    }
}
