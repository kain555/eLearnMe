using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class SzkolyNauczycieli
    {
        public int? NauczycielId { get; set; }
        public int? SzkolaId { get; set; }

        public virtual Nauczyciele Nauczyciel { get; set; }
        public virtual Szkoly Szkola { get; set; }
    }
}
