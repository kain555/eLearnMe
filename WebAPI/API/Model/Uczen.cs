using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class Uczen
    {
        public Uczen()
        {
            Rodzices = new HashSet<Rodzice>();
            WOcenas = new HashSet<WOcena>();
            ZrealizowaneEgzaminies = new HashSet<ZrealizowaneEgzaminy>();
        }

        public int UczenId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime? DataUrodzenia { get; set; }
        public int? Pesel { get; set; }
        public string Email { get; set; }
        public int? LoginId { get; set; }
        public string Adres { get; set; }
        public string KodPocztowy { get; set; }
        public string Miasto { get; set; }
        public int? KlasaId { get; set; }
        public int? SzkolaId { get; set; }

        public virtual Klasy Klasa { get; set; }
        public virtual Szkoly Szkola { get; set; }
        public virtual ICollection<Rodzice> Rodzices { get; set; }
        public virtual ICollection<WOcena> WOcenas { get; set; }
        public virtual ICollection<ZrealizowaneEgzaminy> ZrealizowaneEgzaminies { get; set; }
    }
}
