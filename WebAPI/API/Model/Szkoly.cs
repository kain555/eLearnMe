using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class Szkoly
    {
        public Szkoly()
        {
            Uczen = new HashSet<Uczen>();
        }

        public int SzkolaId { get; set; }
        public string Nazwa { get; set; }
        public string DataZalozenia { get; set; }
        public int? ProfilId { get; set; }
        public string Opis { get; set; }
        public int? DyrId { get; set; }

        public virtual Profile Profil { get; set; }
        public virtual ICollection<Uczen> Uczen { get; set; }
    }
}
