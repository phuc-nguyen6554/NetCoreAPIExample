using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
//using AutoMapper.Configuration;
using ExampleAPI.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ExampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public AuthController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginUser user)
        {
            if (user == null)
            {
                return BadRequest("User is required");
            }

            if (user.Username == "phucnguyen" && user.Password == "1234")
            {
                string JWTKey = configuration["JWT:Secret"];
                string issuer = configuration["JWT:Issuer"];
                string audience = configuration["JWT:Audience"];

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTKey));
                var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var authClaim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username)
                };

                var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: authClaim,
                    signingCredentials: credential,
                    expires: DateTime.Now.AddHours(1)
                );

                var TokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { Token = TokenString });
            }
            else
            {
                return Unauthorized("Username or password is incorrect");
            }
        }
    }
}
