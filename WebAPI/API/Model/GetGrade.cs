using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class GetGrade
    {
        public string DiscipleName { get; set; }
        public string DiscipleSurname { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
        public string SubjectName { get; set; }
        public string GradeName { get; set; }
        public int? GradeValue { get; set; }
        public DateTime? DateIssued { get; set; }
        public int? DiscipleId { get; set; }
        public int? TeacherId { get; set; }
        public int? SubjectId { get; set; }
    }
}
