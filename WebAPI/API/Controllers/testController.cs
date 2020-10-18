using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class testController : Controller
    {
        private readonly eLearnDBContext _context;

        public testController(eLearnDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestTable>>> GetTest()
        {
            return await _context.TestTables.ToListAsync();
        }
    }
}
