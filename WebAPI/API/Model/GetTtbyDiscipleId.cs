using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class GetTtbyDiscipleId
    {
        public string Subject { get; set; }
        public string LessonHour { get; set; }
        public string DayOfWeek { get; set; }
        public int DiscipleId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
        public string ClassName { get; set; }
        public int? DayOfWeekId { get; set; }
    }
}
