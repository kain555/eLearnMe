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
    public class gradesController : BaseController
    {
        private readonly eLearnDBContext _context;

        public gradesController(eLearnDBContext context)
        {
            _context = context;
        }

        [HttpGet("GradesByD")]
        public async Task<List<AllDiscipleGrade>> GradesByD(int id) 
        {
            var returnGrades = await _context.AllDiscipleGrades.Where(s => s.Id == id).ToListAsync();
            return returnGrades.ToList();
        }

        [HttpGet("GradesByDS")]
        public async Task<List<AllDiscipleGrade>> GradesByDS(int id, string subject)
        {
            var returnGrades = await _context.AllDiscipleGrades.Where(s => s.Id == id && s.Subject == subject).ToListAsync();
            return returnGrades.ToList();
        }

        [HttpGet("AverageByDisciple")]
        public string AverageByDisciple(int disciple_id)
        {
            var averageList = new List<double>();
            for (var i = 1; i < 10; i++)
            {
                var gradesArray = _context.GradesIssueds.Where(x => x.SubjectId == i && x.DiscipleId == disciple_id).Select(x => x.GradeId).ToList();
                if (gradesArray.Count != 0)
                {
                    averageList.Add((double)gradesArray.Average());
                }
            }
            var average = averageList.Average();
            return average.ToString("0.##");
        }

    }
}
