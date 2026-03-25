using EventManagementSystem.Dto;
using EventManagementSystem.Interfaces;
using EventManagementSystem.Models;
using EventManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRegistrationDto request)
        {
            var user = await authService.RegisterAsync(request);
            
            if (user is null)
                return BadRequest("Invalid registration");

            return Ok(new { Token = user });
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserLoginDto request)
        {
            var result = await authService.LoginAsync(request);

            if (result is null)
                return Unauthorized("invalid email or password");

            return Ok(result);
        }
    }
   
}
