using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class Profile
    {
        public Profile()
        {
            Szkolies = new HashSet<Szkoly>();
        }

        public int ProfilId { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Szkoly> Szkolies { get; set; }
    }
}
