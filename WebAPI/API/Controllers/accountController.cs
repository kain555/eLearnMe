using API.DTOs;
using API.Interfaces;
using API.Model;
using LinqToDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
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
        public async Task<ActionResult<DiscipleDTO>> NewDisciple(RegisterDTO registerDTO)
        {
            using var hmac = new HMACSHA512();

            if (await UserExists(registerDTO.Login)) return BadRequest("Username is taken");

            var newD = new NewDisciple
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
                ClassId = registerDTO.ClassId
            };
            _context.NewDisciples.Add(newD);
            await _context.SaveChangesAsync();

            return new DiscipleDTO
            {
                Login = newD.Login,
                Token = _tokenService.CreateToken(newD)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<DiscipleDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _context.NewDisciples.SingleOrDefaultAsync(x => x.Login == loginDTO.Login);
            if (user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

            for(int i=0;i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
            }
            return new DiscipleDTO
            {
                Login = user.Login,
                Token = _tokenService.CreateToken(user)
            };
        }
        private async Task<bool> UserExists(string username)
        {
            return await _context.NewDisciples.AnyAsync(x => x.Login == username.ToLower());
        }
    }
}
