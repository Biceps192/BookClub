using BookClubApi.Dto.Auth;
using BookClubApi.Helpers;
using BookClubApi.Models;
using BookClubApi.Data;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BookClubApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserManagementController : ControllerBase
    {
        private readonly BookContext _dbContext;
        private readonly IAuthHelper _authHelper;

        public UserManagementController(BookContext dbContext, IAuthHelper authHelper)
        {
            _dbContext = dbContext;
            _authHelper = authHelper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid registration data.");
            }

            // Check if the username or email is already in use
            if (await _dbContext.Users.AnyAsync(u => u.Username == model.Username || u.Email == model.Email))
            {
                return BadRequest("Username or email is already in use.");
            }

            var hashedPassword = _authHelper.HashPassword(model.Password);

            var user = new User
            {
                Username = model.Username,
                PasswordHash = hashedPassword,
                Email = model.Email
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return Ok("Registration successful.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == model.Username);

            var hashedPassword = _authHelper.HashPassword(model.Password);

            if (user == null || hashedPassword != user.PasswordHash)
            {
                return Unauthorized("Invalid username or password.");
            }

            var token = _authHelper.GenerateJwtToken(user);

            return Ok(new { Token = token });
        }
    }
}
