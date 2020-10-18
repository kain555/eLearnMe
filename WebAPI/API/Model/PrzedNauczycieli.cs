using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class PrzedNauczycieli
    {
        public int? PrzedmiotId { get; set; }
        public int? NauczycielId { get; set; }

        public virtual Nauczyciele Nauczyciel { get; set; }
        public virtual Przedmioty Przedmiot { get; set; }
    }
}
