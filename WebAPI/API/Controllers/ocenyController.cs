using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ocenyController : ControllerBase
    {
        private readonly eLearnDBContext _context;
        public ocenyController(eLearnDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Oceny>>> GetOceny()
        {
            return await _context.Oceny.ToListAsync();
        }
    }
}
