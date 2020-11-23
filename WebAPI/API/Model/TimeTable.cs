using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class TimeTable
    {
        public int TimetableId { get; set; }
        public int? SubjectId { get; set; }
        public int? ClassId { get; set; }
        public string DayOfWeek { get; set; }
        public int? DayOfWeekId { get; set; }
        public int? LessonHourId { get; set; }
        public int? RoomId { get; set; }
        public int? TeacherId { get; set; }
        public string Note { get; set; }

        public virtual Class Class { get; set; }
        public virtual LessonHour LessonHour { get; set; }
        public virtual Room Room { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
