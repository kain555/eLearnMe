using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface ITokenService
    {
        string CreateTokenDisciple(Disciple disciple);
        string CreateTokenTeacher(Teacher teacher);
    }
}
