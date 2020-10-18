using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class Rodzice
    {
        public int RodzicId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime? DataUrodzenia { get; set; }
        public int? DzieckoId { get; set; }
        public string Email { get; set; }
        public int? LoginId { get; set; }
        public string Adres { get; set; }
        public string KodPocztowy { get; set; }
        public string Miasto { get; set; }

        public virtual Uczen Dziecko { get; set; }
    }
}
