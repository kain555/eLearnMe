using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class Question
    {
        public Question()
        {
            TestQuestions = new HashSet<TestQuestion>();
        }

        public int QuestionId { get; set; }
        public string QuestionContent { get; set; }
        public int? MarkId { get; set; }

        public virtual Mark Mark { get; set; }
        public virtual ICollection<TestQuestion> TestQuestions { get; set; }
    }
}
