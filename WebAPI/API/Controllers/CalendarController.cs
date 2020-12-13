using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class CalendarController : BaseController
    {
        private readonly eLearnDBContext _context;
        public CalendarController(eLearnDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<GetCalendarByClassDw>> GetTimeTableDataDay(int classId)
        {
            var data = await _context.GetCalendarByClassDws.Where(s => s.ClassId == classId).ToArrayAsync();
            return data.ToList();
        }
    }
}
