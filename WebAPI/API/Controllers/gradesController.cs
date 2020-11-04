using API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class gradesController : baseController
    {
        private readonly eLearnDBContext _context;

        public gradesController(eLearnDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<AllDiscipleGrade>> dgTEST(int id) {

            var returnGrades = await _context.AllDiscipleGrades.Where(s => s.Id == id).ToListAsync();
        
            return returnGrades.ToList();
        }

}
}
