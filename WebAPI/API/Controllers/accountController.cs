using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class accountController : baseController
    {
        public readonly eLearnDBContext _context;
        public accountController(eLearnDBContext context)
        {
            _context = context;
        }

        [HttpPost("newDisciple")]
        public async Task<ActionResult<NewDisciple>> NewDisciple(int teacherId, DateTime createDate, int schoolId, int ClassId, string login, string name, string surname, string dateOfBirth, int pesel, string email, string address, string postalCode, string city)
        {
            var newD = new NewDisciple
            {
                Status = "Waiting for director",
                TeacherId = teacherId,
                CreateDate = createDate,
                SchoolId = schoolId,
                Login = login,
                Name = name,
                Surname = surname,
                DateOfBirth = dateOfBirth,
                Pesel = pesel,
                Email = email,
                Address = address,
                PostalCode = postalCode,
                City = city,
                ClassId = ClassId
            };
            _context.NewDisciples.Add(newD);
            await _context.SaveChangesAsync();

            return newD;
        }
    }
}
