using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class Teacher
    {
        public Teacher()
        {
            GradesIssueds = new HashSet<GradesIssued>();
            NewDisciples = new HashSet<NewDisciple>();
            TeachersClasses = new HashSet<TeachersClass>();
        }

        public int TeacherId { get; set; }
        public string Login { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Pesel { get; set; }
        public int? SubjectId { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public int? SchoolId { get; set; }
        public bool? WhetherDirector { get; set; }

        public virtual School School { get; set; }
        public virtual ICollection<GradesIssued> GradesIssueds { get; set; }
        public virtual ICollection<NewDisciple> NewDisciples { get; set; }
        public virtual ICollection<TeachersClass> TeachersClasses { get; set; }
    }
}
