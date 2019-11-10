using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using webAPI.Data;
using webAPI.Dtos;
using webAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace webAPI.Controllers
{  
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public AuthController (IAuthRepository repo, IConfiguration config, IMapper mapper)
        {
            _repo = repo;
            _config = config;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register (UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.Email = userForRegisterDto.Email.ToLower();
            if (await _repo.UserExists(userForRegisterDto.Email))
                return BadRequest ("Email already exist");

            var userToCreate = new User
            {
                Email = userForRegisterDto.Email,
                Name = userForRegisterDto.Name,
                LastName = userForRegisterDto.LastName
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);
           return StatusCode(201);
        }

        [HttpPost("login")]
         public async Task<IActionResult> Login (UserForLoginDto userForLoginDto)
         {

         
            var userFromRepo = await _repo.Login(userForLoginDto.Email.ToLower(), userForLoginDto.Password);
            if(userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim (ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim (ClaimTypes.Email, userFromRepo.Email)
            };
            var key = new SymmetricSecurityKey (Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor 
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var user = _mapper.Map<UserForListDto>(userFromRepo);

            return Ok(new {
                token = tokenHandler.WriteToken(token),
                user
            });
         }
    };
}