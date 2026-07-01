using Microsoft.AspNetCore.Mvc;
using HRManagementSystem.API.Data;
using HRManagementSystem.API.DTOs;
using HRManagementSystem.API.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace HRManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {
       private readonly ApplicationDbContext _context;
        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = new user 
            {
                Name = dto.username,
                Email = dto.email,
                Password = dto.password
            };

            _context.users.Add(user);
            _context.SaveChanges();

            return Ok("User Registered Successfully");
        }
        [HttpPost("login")]
        public IActionResult login(RegisterDto dto)
        {
            var user = _context.users.FirstOrDefault(x => x.Email == dto.email && x.Password == dto.password);
            if (user == null) 
            {
                return Unauthorized("invalied email or password");
            }
            var claims = new[]
   {
        new Claim(ClaimTypes.Name, user.Name),
        new Claim(ClaimTypes.Email, user.Email)
    };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("THIS_IS_MY_SECRET_KEY_12345"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "HRSystem",
                audience: "HRSystemUsers",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
