using API.DTOs;
using API.Interfaces;
using API.Model;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class accountController : BaseController
    {
        public readonly eLearnDBContext _context;
        private readonly ITokenService _tokenService;

        public accountController(eLearnDBContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        private Random newGen = new Random();
        DateTime RandomDayDiciple()
        {
            DateTime start = new DateTime(1996, 1, 1);
            DateTime end = new DateTime(2010, 1, 1);
            int range = (end - start).Days;
            return start.AddDays(newGen.Next(range));
        }

        static Random r = new Random();
        int rInt = r.Next(1, 30);

        [HttpPost("newDisciple")]
        public async Task<ActionResult<List<Disciple>>> NewDisciple(List<RegisterDiscipleDTO> registerDTO)
        {
            using var hmac = new HMACSHA512();
            List<Disciple> disciples = new List<Disciple>();
            for (int i = 0; i < registerDTO.Count; i++)
            {
                if (await UserExists(registerDTO[i].Login)) return BadRequest("Username is taken " + registerDTO[i].Login);

                var newD = new Disciple
                {
                    TeacherId = 1,
                    CreateDate = null,
                    Login = registerDTO[i].Login.ToLower(),
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO[i].Password)),
                    PasswordSalt = hmac.Key,
                    Name = registerDTO[i].Name,
                    Surname = registerDTO[i].Surname,
                    DateOfBirth = RandomDayDiciple().ToString(),
                    Pesel = registerDTO[i].Pesel,
                    Email = registerDTO[i].Email,
                    Address = registerDTO[i].Address,
                    PostalCode = registerDTO[i].PostalCode,
                    City = registerDTO[i].City,
                    ClassId = registerDTO[i].ClassId,
                    Active = true
                };
                _context.Disciples.Add(newD);
                await _context.SaveChangesAsync();

                disciples.Add(newD);
                //return new TokenDTO
                //{
                //    Login = newD.Login,
                //    Token = _tokenService.CreateTokenDisciple(newD)
                //};
            }
            return disciples;
        }

        private Random gen = new Random();
        DateTime RandomDay()
        {
            DateTime start = new DateTime(1940, 1, 1);
            DateTime end = new DateTime(1995, 1, 1);
            int range = (end - start).Days;
            return start.AddDays(gen.Next(range));
        }

        [HttpPost("newTeacher")]
        public async Task<ActionResult<List<Teacher>>> NewTeacher(List<RegisterTeacherDTO> teacherDTO)
        {
            using var hmac = new HMACSHA512();
            List<Teacher> teachers = new List<Teacher>();

            for (int i = 0; i < teacherDTO.Count; i++)
            { 
            if (await UserExists(teacherDTO[i].Login)) return BadRequest("Username is taken");

            var teacher = new Teacher
            {

                Login = teacherDTO[i].Login,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(teacherDTO[i].Password)),
                PasswordSalt = hmac.Key,
                Name = teacherDTO[i].Name,
                Surname = teacherDTO[i].Surname,
                DateOfBirth = RandomDay(),
                Pesel = teacherDTO[i].Pesel,
                Address = teacherDTO[i].Address,
                PostalCode = teacherDTO[i].PostalCode,
                City = teacherDTO[i].City,
                WhetherDirector = teacherDTO[i].whether_director
            };
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
                teachers.Add(teacher);
            }
            return teachers;
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
                    Token = _tokenService.CreateTokenDisciple(user),
                    ClassId = (int)user.ClassId,
                    Id = user.NdId
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
                        Token = _tokenService.CreateTokenTeacher(teacher),
                        Id = teacher.TeacherId
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
