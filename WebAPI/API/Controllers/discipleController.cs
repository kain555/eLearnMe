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
        public async Task<ActionResult<IEnumerable<Disciple>>> GetDisciple()
        {
            return await _context.Disciples.ToListAsync();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Disciple>> GetDisciple(int id)
        {
            return await _context.Disciples.FindAsync(id);
        }

        [HttpPost("registerDisciple")]
        public async Task<ActionResult<RegisterDisciple>> registerDisciple(RegisterDisciple registerDisciple)
        {
            if (await DiscipleExists(registerDisciple.NdId)) return BadRequest("Disciple process is running");

            var regDisciple = new RegisterDisciple
            {
                NdId = registerDisciple.NdId,
                Date = registerDisciple.Date,
                TeacherId = registerDisciple.TeacherId,
                ClassId = registerDisciple.ClassId,
                Status = "Proces rejestracji uruchomiony przez nauczyciela, czeka na akceptacje dyrektora"
            };
            _context.RegisterDisciples.Add(regDisciple);
            await _context.SaveChangesAsync();

            return registerDisciple;
        }

        private async Task<bool> DiscipleExists(int? nd)
        {
            return await _context.Disciples.AnyAsync(x => x.NdId == nd);
        }

    }
}
