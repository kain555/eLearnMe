using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class CompletedExam
    {
        public int CeId { get; set; }
        public int? ExamId { get; set; }
        public int? DiscipleId { get; set; }
        public bool? Gained { get; set; }
        public DateTime? Date { get; set; }

        public virtual Disciple Disciple { get; set; }
        public virtual Exam Exam { get; set; }
    }
}
