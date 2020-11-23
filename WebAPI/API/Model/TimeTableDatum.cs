using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class TimeTableDatum
    {
        public string DayOfWeek { get; set; }
        public int? DayOfWeekId { get; set; }
        public string Note { get; set; }
        public int? ClassId { get; set; }
        public string ClassName { get; set; }
        public int? SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int? LessonHourId { get; set; }
        public string LessonHourName { get; set; }
        public int? RoomId { get; set; }
        public string RoomName { get; set; }
        public int? TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
    }
}
