using API.DTOs;
using API.Interfaces;
using API.Model;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class accountController : baseController
    {
        public readonly eLearnDBContext _context;
        private readonly ITokenService _tokenService;

        public accountController(eLearnDBContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("newDisciple")]
        public async Task<ActionResult<TokenDTO>> NewDisciple(RegisterDiscipleDTO registerDTO)
        {
            using var hmac = new HMACSHA512();

            if (await UserExists(registerDTO.Login)) return BadRequest("Username is taken");

            var newD = new Disciple
            {
                TeacherId = registerDTO.TeacherId,
                CreateDate = registerDTO.CreateDate,
                SchoolId = registerDTO.SchoolId,
                Login = registerDTO.Login.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password)),
                PasswordSalt = hmac.Key,
                Name = registerDTO.Name,
                Surname = registerDTO.Surname,
                DateOfBirth = registerDTO.DateOfBirth,
                Pesel = registerDTO.Pesel,
                Email = registerDTO.Email,
                Address = registerDTO.Address,
                PostalCode = registerDTO.PostalCode,
                City = registerDTO.City,
                ClassId = registerDTO.ClassId,
                Active = false
            };
            _context.Disciples.Add(newD);
            await _context.SaveChangesAsync();

            return new TokenDTO
            {
                Login = newD.Login,
                Token = _tokenService.CreateTokenDisciple(newD)
            };
        }

        [HttpPost("newTeacher")]
        public async Task<ActionResult<TokenDTO>> NewTeacher(RegisterTeacherDTO teacherDTO)
        {
            using var hmac = new HMACSHA512();

            if (await UserExists(teacherDTO.Login)) return BadRequest("Username is taken");

            var teacher = new Teacher
            {
                Login = teacherDTO.Login,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(teacherDTO.Password)),
                PasswordSalt = hmac.Key,
                Name = teacherDTO.Name,
                Surname = teacherDTO.Surname,
                DateOfBirth = teacherDTO.DateOfBirth,
                Pesel = teacherDTO.Pesel,
                Address = teacherDTO.Address,
                PostalCode = teacherDTO.PostalCode,
                City = teacherDTO.City,
                WhetherDirector = teacherDTO.whether_director,
                SubjectId = teacherDTO.subject_id
            };
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return new TokenDTO
            {
                Login = teacher.Login,
                Token = _tokenService.CreateTokenTeacher(teacher)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _context.Disciples.SingleOrDefaultAsync(x => x.Login == loginDTO.Login);
            if (user != null)
            {
                using var hmac = new HMACSHA512(user.PasswordSalt);

                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
                }
                return new TokenDTO
                {
                    Login = user.Login,
                    Token = _tokenService.CreateTokenDisciple(user)
                };
            }
            else if (user == null)
            {
                var teacher = await _context.Teachers.SingleOrDefaultAsync(x => x.Login == loginDTO.Login);
                if (teacher != null)
                {
                    using var hmac = new HMACSHA512(teacher.PasswordSalt);

                    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

                    for (int i = 0; i < computedHash.Length; i++)
                    {
                        if (computedHash[i] != teacher.PasswordHash[i]) return Unauthorized("Invalid Password");
                    }
                    return new TokenDTO
                    {
                        Login = teacher.Login,
                        Token = _tokenService.CreateTokenTeacher(teacher)
                    };
                }
            }
            return Unauthorized("Invalid username");
        }
        private async Task<bool> UserExists(string username)
        {
            return await _context.AllLogins.AnyAsync(x => x.Login == username.ToLower());

        }
    }
}
