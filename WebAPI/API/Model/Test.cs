using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class Test
    {
        public Test()
        {
            TestQuestions = new HashSet<TestQuestion>();
        }

        public int TestId { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ClassId { get; set; }
        public int? TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual Class TestNavigation { get; set; }
        public virtual ICollection<TestQuestion> TestQuestions { get; set; }
    }
}
