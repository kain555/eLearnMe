using API.Model;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class SchoolController : baseController
    {
        private readonly eLearnDBContext _context;
        public SchoolController(eLearnDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<School> getSchool(int id)
        {
            var returnTTByDisciple = await _context.Schools.Where(s => s.SchoolId == id).FirstOrDefaultAsync();
            return returnTTByDisciple;
        }
    }
}
