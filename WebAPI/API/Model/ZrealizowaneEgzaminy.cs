using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class ZrealizowaneEgzaminy
    {
        public int EzId { get; set; }
        public int? EgzaminId { get; set; }
        public int? UczenId { get; set; }
        public DateTime? Data { get; set; }

        public virtual Egzaminy Egzamin { get; set; }
        public virtual Uczen Uczen { get; set; }
    }
}
