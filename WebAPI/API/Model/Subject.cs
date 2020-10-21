using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class Subject
    {
        public Subject()
        {
            GradesIssueds = new HashSet<GradesIssued>();
        }

        public int SubjectId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GradesIssued> GradesIssueds { get; set; }
    }
}
