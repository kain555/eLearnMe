using System;
using System.Collections.Generic;

#nullable disable

namespace API.Model
{
    public partial class Teacher
    {
        public Teacher()
        {
            Disciples = new HashSet<Disciple>();
            GradesIssueds = new HashSet<GradesIssued>();
            TeachersClasses = new HashSet<TeachersClass>();
            Tests = new HashSet<Test>();
            TimeTables = new HashSet<TimeTable>();
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
        public bool? WhetherDirector { get; set; }

        public virtual ICollection<Disciple> Disciples { get; set; }
        public virtual ICollection<GradesIssued> GradesIssueds { get; set; }
        public virtual ICollection<TeachersClass> TeachersClasses { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
        public virtual ICollection<TimeTable> TimeTables { get; set; }
    }
}
