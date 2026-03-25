using EventManagementSystem.Dto;
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
    
    public class EventController(IEventService eventService) : ControllerBase
    {
        [EnableRateLimiting("UserRateLimit")]
        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await eventService.GetAllAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(Guid id)
        {
            var events = await eventService.GetEventByIdAsync(id);

            if (events is null)
                return NotFound();
            return Ok(events);
        }

        [Authorize(Roles ="Admin,Organizer")]
        [HttpPost]
        public async Task<IActionResult> CreateEvent(EventCreateDto request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userId is null)
                return Unauthorized("Invalid token");
            var organizerId = Guid.Parse(userId.Value);
            var createdEvent = await eventService.CreateEventAsync(request, organizerId);

            return Ok(createdEvent);
        }

        [Authorize(Roles = "Admin,Organizer")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(Guid id,EventUpdateDto request)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var role = User.FindFirstValue(ClaimTypes.Role)!;
            var updated = await eventService.UpdateEventAsync(id,request,userId,role);
           
            if (updated is null)
                return NotFound();
         
            return Ok(updated);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var role = User.FindFirstValue(ClaimTypes.Role)!;
            var deleted = await eventService.DeleteEventAsync(id,userId,role);
            if (!deleted)
                return NotFound();
            if (deleted == false)
                return Forbid("You cannot delete someone else's event");
            return NoContent();
        }
    }
}
