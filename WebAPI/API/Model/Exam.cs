using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class Exam
    {
        public Exam()
        {
            CompletedExams = new HashSet<CompletedExam>();
        }

        public int ExamId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CompletedExam> CompletedExams { get; set; }
    }
}
