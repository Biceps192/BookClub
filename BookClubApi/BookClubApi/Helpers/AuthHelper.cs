using BookClubApi.Models;
using BookClubApi.Data;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BookClubApi.Helpers
{
    public interface IAuthHelper
    {
        string GenerateJwtToken(User user);
        string HashPassword(string password);
    }
    public class AuthHelper: IAuthHelper
    {
        private readonly IConfiguration _configuration;
        private readonly BookContext _dbContext;

        public AuthHelper(IConfiguration configuration, BookContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
            };
            //// Include roles and permissions from the database
            //var userRoles = _dbContext.UserRoles
            //    .Include(ur => ur.Role)
            //    .Where(ur => ur.UserId == user.Id)
            //    .ToList();

            //claims.AddRange(userRoles.Select(ur => new Claim(ClaimTypes.Role, ur.Role.Name)));

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string HashPassword(string password)
        {
            byte[] salt = new byte[]
                    {
                        0x01, 0x02, 0x0A, 0xFF,
                        0x11, 0x22, 0x33, 0x44,
                    };
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return hashedPassword;
        }
    }
}
