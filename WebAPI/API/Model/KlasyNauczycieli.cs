using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class KlasyNauczycieli
    {
        public int KnId { get; set; }
        public int? NauczycielId { get; set; }
        public int? KlasaId { get; set; }
        public bool? CzyWych { get; set; }

        public virtual Klasy Klasa { get; set; }
        public virtual Nauczyciele Nauczyciel { get; set; }
    }
}
