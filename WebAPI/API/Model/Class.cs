using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class Class
    {
        public Class()
        {
            NewDisciples = new HashSet<NewDisciple>();
            TeachersClasses = new HashSet<TeachersClass>();
        }

        public int ClassId { get; set; }
        public string Name { get; set; }
        public int? SchoolId { get; set; }

        public virtual ICollection<NewDisciple> NewDisciples { get; set; }
        public virtual ICollection<TeachersClass> TeachersClasses { get; set; }
    }
}
