using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class TeachersSubject
    {
        public int? SubjectId { get; set; }
        public int? TeacherId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
