using API.Model;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AnnounceController : BaseController
    {
        private readonly eLearnDBContext _context;

        public AnnounceController(eLearnDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<Announce>> GetAnnounces(int schoolId)
        {
            var announces = await _context.Announces.Where(x => x.SchoolId == schoolId).ToListAsync();
            return announces;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Announce>> GetAnnounce(int id)
        {
            return await _context.Announces.FindAsync(id);
        }
    }
}
