using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class RegisterDiscipleDTO
    {
        [Required]
        public int TeacherId { get; set; }
        [Required]
        public DateTime? CreateDate { get; set; }
        [Required]
        public int SchoolId { get; set; }
        [Required]
        public int ClassId { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string Pesel { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string City { get; set; }
    }
}
