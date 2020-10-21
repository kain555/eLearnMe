using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class TeachersClass
    {
        public int TcId { get; set; }
        public int? TeacherId { get; set; }
        public int? ClassId { get; set; }
        public bool? WhetherEducator { get; set; }

        public virtual Class Class { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
