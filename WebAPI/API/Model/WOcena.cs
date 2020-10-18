using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class WOcena
    {
        public int WoId { get; set; }
        public int? UczenId { get; set; }
        public int? NauczycielId { get; set; }
        public DateTime? DataWystawienia { get; set; }
        public int? PrzedmiotId { get; set; }
        public int? OcenaId { get; set; }

        public virtual Nauczyciele Nauczyciel { get; set; }
        public virtual Oceny Ocena { get; set; }
        public virtual Przedmioty Przedmiot { get; set; }
        public virtual Uczen Uczen { get; set; }
    }
}
