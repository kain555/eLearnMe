using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class Mark
    {
        public Mark()
        {
            Questions = new HashSet<Question>();
        }

        public int MarkId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
