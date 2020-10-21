using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class SchoolProfile
    {
        public SchoolProfile()
        {
            Schools = new HashSet<School>();
        }

        public int ProfileId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<School> Schools { get; set; }
    }
}
