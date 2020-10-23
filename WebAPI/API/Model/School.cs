using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class School
    {
        public School()
        {
            Disciples = new HashSet<Disciple>();
            NewDisciples = new HashSet<NewDisciple>();
            Teachers = new HashSet<Teacher>();
        }

        public int SchoolId { get; set; }
        public string Name { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? TypeId { get; set; }
        public int? ProfileId { get; set; }
        public string Description { get; set; }
        public int? DirectorId { get; set; }

        public virtual SchoolProfile Profile { get; set; }
        public virtual SchoolsType Type { get; set; }
        public virtual ICollection<Disciple> Disciples { get; set; }
        public virtual ICollection<NewDisciple> NewDisciples { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
