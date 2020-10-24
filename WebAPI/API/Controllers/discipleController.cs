using API.Model;
using LinqToDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class discipleController : baseController
    {
        private readonly eLearnDBContext _context;

        public discipleController(eLearnDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<NewDisciple>>> GetDisciple()
        {
            return await _context.NewDisciples.ToListAsync();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<NewDisciple>> GetDisciple(int id)
        {
            return await _context.NewDisciples.FindAsync(id);
        }
    }
}
