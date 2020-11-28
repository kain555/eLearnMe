using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class LuckyNumber
    {
        public int LuckyNumberId { get; set; }
        public int? LuckyNumber1 { get; set; }
        public int? SchoolId { get; set; }
        public DateTime? Date { get; set; }

        public virtual School School { get; set; }
    }
}
