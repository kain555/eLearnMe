using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class Egzaminy
    {
        public Egzaminy()
        {
            ZrealizowaneEgzaminies = new HashSet<ZrealizowaneEgzaminy>();
        }

        public int EgzaminId { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<ZrealizowaneEgzaminy> ZrealizowaneEgzaminies { get; set; }
    }
}
