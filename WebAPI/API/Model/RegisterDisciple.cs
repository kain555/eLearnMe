using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class RegisterDisciple
    {
        public int RegisterDId { get; set; }
        public DateTime? Date { get; set; }
        public int? NdId { get; set; }
        public int? TeacherId { get; set; }
        public int? ClassId { get; set; }
        public int? SchoolId { get; set; }
        public string StatusId { get; set; }

        public virtual Class Class { get; set; }
        public virtual NewDisciple Nd { get; set; }
        public virtual School School { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
