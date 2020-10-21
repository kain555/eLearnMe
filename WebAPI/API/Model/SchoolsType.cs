using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class SchoolsType
    {
        public SchoolsType()
        {
            Schools = new HashSet<School>();
        }

        public int TypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<School> Schools { get; set; }
    }
}
