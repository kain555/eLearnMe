using API.Interfaces;
using API.Model;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class TeachersController : baseController
    {
        public readonly eLearnDBContext _context;

        public TeachersController(eLearnDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<TeachingStaff>> GetTimeTableDataWeek(int schoolId)
        {
            var returnTTByDisciple = await _context.TeachingStaffs.Where(s => s.SchoolId == schoolId).ToArrayAsync();
            return returnTTByDisciple.ToList();
        }
    }
}
