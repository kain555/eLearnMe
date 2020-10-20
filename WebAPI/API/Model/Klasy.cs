using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class Klasy
    {
        public Klasy()
        {
            KlasyNauczycieli = new HashSet<KlasyNauczycieli>();
            Uczens = new HashSet<Uczen>();
        }

        public int KlasaId { get; set; }
        public string Nazwa { get; set; }
        public int? SzkolaId { get; set; }

        public virtual ICollection<KlasyNauczycieli> KlasyNauczycieli { get; set; }
        public virtual ICollection<Uczen> Uczens { get; set; }
    }
}
