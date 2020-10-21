using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class NewDisciple
    {
        public int NdId { get; set; }
        public string Status { get; set; }
        public int? TeacherId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? SchoolId { get; set; }
        public int? ClassId { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
        public int? Pesel { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public virtual Class Class { get; set; }
        public virtual School School { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
