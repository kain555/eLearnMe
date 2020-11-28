using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class TokenDTO
    {
        public string Login { get; set; }
        public string Token { get; set; }
        public int Id { get; set; }
        public int ClassId { get; set; }
    }
}
