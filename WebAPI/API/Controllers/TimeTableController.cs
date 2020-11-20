﻿using API.Model;
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

        [HttpGet("GetTimeTableDataDay")]
        public async Task<List<GetTimeTableData>> GetTimeTableDataDay(int classId, int day, int schoolId)
        {
            var returnTTByDisciple = await _context.GetTimeTableData.Where(s => s.DayOfWeekId == day && s.ClassId == classId && s.SchoolId == schoolId).ToArrayAsync();
            return returnTTByDisciple.ToList();
        }
        [HttpGet("GetTimeTableDataWeek")]
        public async Task<List<GetTimeTableData>> GetTimeTableDataWeek(int classId, int schoolId)
        {
            var returnTTByDisciple = await _context.GetTimeTableData.Where(s => s.ClassId == classId && s.SchoolId == schoolId).ToArrayAsync();
            return returnTTByDisciple.ToList();
        }
    }
}
