using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class DiscipleGradesAll
    {
        public string DiscipleName { get; set; }
        public string DiscipleSurname { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
        public DateTime? GiDate { get; set; }
        public string Subject { get; set; }
        public int? GValue { get; set; }
        public string GName { get; set; }
    }
}
