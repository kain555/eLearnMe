using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class TestQuestion
    {
        public int TqId { get; set; }
        public int? TestId { get; set; }
        public int? QuestionId { get; set; }
        public int? Points { get; set; }
        public int? GoodAnswer { get; set; }

        public virtual Question Question { get; set; }
        public virtual Test Test { get; set; }
    }
}
