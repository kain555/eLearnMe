using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class TimeTableController : baseController
    {
        private readonly eLearnDBContext _context;
        public TimeTableController(eLearnDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<GetTimeTableData>> GetTimeTableData(int classId, int day)
        {
            var returnTTByDisciple = await _context.GetTimeTableData.Where(s => s.DayOfWeekId == day && s.ClassId == classId).ToArrayAsync();
            return returnTTByDisciple.ToList();
        }
    }
}
