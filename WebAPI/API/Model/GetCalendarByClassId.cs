using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class GetCalendarByClassId
    {
        public int TimeTableId { get; set; }
        public string SubjectName { get; set; }
        public int? LessonHourS { get; set; }
        public int? LessonMinuteS { get; set; }
        public int? LessonHourE { get; set; }
        public int? LessonMinuteE { get; set; }
        public string Note { get; set; }
        public int? ClassId { get; set; }
    }
}
