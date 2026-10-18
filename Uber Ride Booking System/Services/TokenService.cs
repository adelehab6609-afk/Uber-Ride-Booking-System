using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Xml;
using Uber_Ride_Booking_System.Data;
using Uber_Ride_Booking_System.DOTS.User;
using Uber_Ride_Booking_System.Models;

namespace Uber_Ride_Booking_System.Services
{
    public class TokenService : ITokenService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        public TokenService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public string CreateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claimssss = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                new Claim(ClaimTypes.Role , user.Role),
                new Claim(ClaimTypes.Email , user.Email),
            };
            var token = new JwtSecurityToken(
                claims: claimssss,
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                signingCredentials: creds,
                expires: DateTime.Now.AddHours(2)


                );
            return new JwtSecurityTokenHandler ().WriteToken(token);
        }

        public string Login(LoginDto loginDto)
        {
            var a = _context.Users.Where( a=> a.Email == loginDto.Email && a.PasswordHash == loginDto.Password ).First();
            var m = CreateToken(a);
            return (m);
        }
    }
}
