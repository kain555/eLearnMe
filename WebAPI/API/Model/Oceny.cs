﻿using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class Oceny
    {
        public Oceny()
        {
            WOcenas = new HashSet<WOcena>();
        }

        public int OcenaId { get; set; }
        public string Nazwa { get; set; }
        public int? Wartosc { get; set; }

        public virtual ICollection<WOcena> WOcenas { get; set; }
    }
}