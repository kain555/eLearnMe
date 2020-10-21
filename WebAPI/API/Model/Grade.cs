using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class Grade
    {
        public Grade()
        {
            GradesIssueds = new HashSet<GradesIssued>();
        }

        public int GradeId { get; set; }
        public string Name { get; set; }
        public int? Value { get; set; }

        public virtual ICollection<GradesIssued> GradesIssueds { get; set; }
    }
}
