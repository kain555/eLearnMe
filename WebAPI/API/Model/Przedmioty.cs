using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class Przedmioty
    {
        public Przedmioty()
        {
            WOcenas = new HashSet<WOcena>();
        }

        public int PrzedmiotId { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<WOcena> WOcenas { get; set; }
    }
}
