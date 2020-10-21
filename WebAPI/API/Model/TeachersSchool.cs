using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class TeachersSchool
    {
        public int? TeacherId { get; set; }
        public int? SchoolId { get; set; }

        public virtual School School { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
