using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class Nauczyciele
    {
        public Nauczyciele()
        {
            KlasyNauczycielis = new HashSet<KlasyNauczycieli>();
            WOcenas = new HashSet<WOcena>();
        }

        public int NauczycielId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime? DataUrodzenia { get; set; }
        public int? Pesel { get; set; }
        public string Email { get; set; }
        public int? LoginId { get; set; }
        public int? PrzedmiotId { get; set; }
        public string Adres { get; set; }
        public string KodPocztowy { get; set; }
        public string Miasto { get; set; }
        public int? SzkolaId { get; set; }
        public int? KnId { get; set; }
        public bool? CzyDyr { get; set; }

        public virtual ICollection<KlasyNauczycieli> KlasyNauczycielis { get; set; }
        public virtual ICollection<WOcena> WOcenas { get; set; }
    }
}
