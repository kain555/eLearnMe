using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class SchoolAnnouncement
    {
        public int SchoolId { get; set; }
        public int AnnounceId { get; set; }

        public virtual Announce Announce { get; set; }
        public virtual School School { get; set; }
    }
}
