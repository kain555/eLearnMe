using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class Room
    {
        public Room()
        {
            TimeTables = new HashSet<TimeTable>();
        }

        public int RoomId { get; set; }
        public string Name { get; set; }
        public int? SchoolId { get; set; }

        public virtual School School { get; set; }
        public virtual ICollection<TimeTable> TimeTables { get; set; }
    }
}
