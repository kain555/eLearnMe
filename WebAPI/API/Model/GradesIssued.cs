using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class GradesIssued
    {
        public int GiId { get; set; }
        public int? DiscipleId { get; set; }
        public int? TeacherId { get; set; }
        public DateTime? DateIssued { get; set; }
        public int? SubjectId { get; set; }
        public int? GradeId { get; set; }

        public virtual NewDisciple Disciple { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
