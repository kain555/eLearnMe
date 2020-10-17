using API.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
        public ActionResult<IEnumerable<TestTable>> GetTest()
        {
            return _context.TestTables.ToList();
        }
    }
}
