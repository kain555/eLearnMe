using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class TeachingStaff
    {
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
        public string TeacherLogin { get; set; }
        public int TeacherId { get; set; }
        public bool? Director { get; set; }
        public int? ClassId { get; set; }
        public string ClassName { get; set; }
        public bool? Educator { get; set; }
        public int? SchoolId { get; set; }
        public string SchoolName { get; set; }
        public int? SubjectId { get; set; }
        public string SubjectName { get; set; }
    }
}
