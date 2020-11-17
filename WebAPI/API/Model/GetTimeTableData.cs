using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class GetTimeTableData
    {
        public string DayOfWeek { get; set; }
        public int? DayOfWeekId { get; set; }
        public string Subject { get; set; }
        public string ClassName { get; set; }
        public int ClassId { get; set; }
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string LessonHour { get; set; }
        public int LessonHourId { get; set; }
        public string RoomName { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
        public int TeacheId { get; set; }
    }
}
