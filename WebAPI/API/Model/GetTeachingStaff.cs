using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class GetTeachingStaff
    {
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
        public int TeacherId { get; set; }
        public string ClassName { get; set; }
        public int? ClassId { get; set; }
        public int? SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string SubjectName { get; set; }
        public int SubjectId { get; set; }
        public string Login { get; set; }
    }
}
