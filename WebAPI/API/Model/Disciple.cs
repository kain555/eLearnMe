using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class Disciple
    {
        public Disciple()
        {
            CompletedExams = new HashSet<CompletedExam>();
            GradesIssueds = new HashSet<GradesIssued>();
        }

        public int NdId { get; set; }
        public string Login { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
        public string Pesel { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? Active { get; set; }
        public int? TeacherId { get; set; }
        public int? SchoolId { get; set; }
        public int? ClassId { get; set; }

        public virtual Class Class { get; set; }
        public virtual School School { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<CompletedExam> CompletedExams { get; set; }
        public virtual ICollection<GradesIssued> GradesIssueds { get; set; }
    }
}
