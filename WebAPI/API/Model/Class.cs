using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class Class
    {
        public Class()
        {
            Disciples = new HashSet<Disciple>();
            TeachersClasses = new HashSet<TeachersClass>();
            TimeTables = new HashSet<TimeTable>();
        }

        public int ClassId { get; set; }
        public string Name { get; set; }
        public int? SchoolId { get; set; }

        public virtual Test Test { get; set; }
        public virtual ICollection<Disciple> Disciples { get; set; }
        public virtual ICollection<TeachersClass> TeachersClasses { get; set; }
        public virtual ICollection<TimeTable> TimeTables { get; set; }
    }
}
