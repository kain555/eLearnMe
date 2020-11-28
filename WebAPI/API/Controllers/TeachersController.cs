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
    public class TeachersController : BaseController
    {
        public readonly eLearnDBContext _context;

        public TeachersController(eLearnDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<GetTeachingStaff>> getTeachingStaff(int schoolId)
        {
            var returnTTByDisciple = await _context.GetTeachingStaffs.Where(s => s.SchoolId == schoolId).ToArrayAsync();
            return returnTTByDisciple.ToList();
        }
    }
}
