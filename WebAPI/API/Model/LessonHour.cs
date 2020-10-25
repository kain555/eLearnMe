using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class LessonHour
    {
        public LessonHour()
        {
            TimeTables = new HashSet<TimeTable>();
        }

        public int LessonHourId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TimeTable> TimeTables { get; set; }
    }
}
