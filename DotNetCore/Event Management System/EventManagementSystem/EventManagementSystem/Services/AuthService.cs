using EventManagementSystem.Data;
using EventManagementSystem.Dto;
using EventManagementSystem.Interfaces;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventManagementSystem.Services
{
    public class AuthService(AppDbContext context, IConfiguration configuration) : IAuthService
    {
        public async Task<AuthResponseDto> LoginAsync(UserLoginDto request)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user is null)
                return null;

            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password)
                == PasswordVerificationResult.Failed)
                return null;

            var token = CreateToken(user);

            return new AuthResponseDto
            {

                Token = token,
                UserId=user.UserId,
                UserName=user.UserName,
                Role=user.Role
            };
        }

        public async Task<AuthResponseDto> RegisterAsync(UserRegistrationDto request)
        {
            if (request.Role != "Admin" && request.Role != "Organizer" && request.Role != "Attendee")
            {
                return null;
            }
            if (await context.Users.AnyAsync(u => u.Email == request.Email))
            {
                return null;
            }
            var user = new User();
            var HashPassword = new PasswordHasher<User>().HashPassword(user, request.Password);

            user.UserName = request.UserName;
            user.Email = request.Email;
            user.Role = request.Role;
            user.PasswordHash = HashPassword;
            user.CreatedAt = DateTime.UtcNow;

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return new AuthResponseDto
            {
                Token = CreateToken(user),
                UserId = user.UserId,
                UserName = user.UserName,
                Role = user.Role
            };
        }
        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims = claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
