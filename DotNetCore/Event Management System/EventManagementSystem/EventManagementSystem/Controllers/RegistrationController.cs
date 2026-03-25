using EventManagementSystem.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Security.Claims;

namespace EventManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegistrationController(IRegistrationService registrationService) : ControllerBase
    {
        [Authorize(Roles = "Attendee")]
        [EnableRateLimiting("UserRateLimit")]
        [HttpPost("{eventId}")]
        public async Task<IActionResult> Register(Guid eventId)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var result = await registrationService.RegisterForEventAsync(userId, eventId);
            if (!result)
                return BadRequest("Already registered");

            return Ok("Registration successful");
        }
        [Authorize(Roles = "Attendee")]
        [HttpDelete("{eventId}")]
        public async Task<IActionResult> Cancel(Guid eventId)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var result = await registrationService.CancelRegistrationAsync(userId, eventId);
            if (!result)
                return BadRequest("registration not found");

            return Ok("Registration cancelled");
        }

        [Authorize(Roles = "Attendee")]
        [HttpGet]
        public async Task<IActionResult> MyRegistration()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await registrationService.GetUserRegistrationAsync(userId);
            return Ok(result);
        }

        [Authorize(Roles = "Organizer")]
        [HttpGet("my-events")]
        public async Task<IActionResult> GetOrganizerRegistrations()
        {
            var organizerId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var registrations = await registrationService.GetRegistrationsForOrganizerAsync(organizerId);

            return Ok(registrations);
        }

        [Authorize]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllRegistrations()
        {
            var registrations = await registrationService.GetAllRegistrationsAsync();
            return Ok(registrations);
        }
    }
}
