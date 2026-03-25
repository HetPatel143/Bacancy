using EventManagementSystem.Data;
using EventManagementSystem.Dto;
using EventManagementSystem.Interfaces;
using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EventManagementSystem.Services
{
    public class EventService(AppDbContext context) : IEventService
    {
        public async Task<IEnumerable<EventResponseDto>> GetAllAsync()
        {
            var events=await context.Events.Include(e => e.Organizer).ToListAsync();
            return events.Select(MapToDto);
        }

        public async Task<EventResponseDto?> GetEventByIdAsync(Guid id)
        {
            var eventId = await context.Events.Include(e => e.Organizer)
                .FirstOrDefaultAsync(e => e.EventId == id);

            if (eventId is null)
                return null;

            return MapToDto(eventId);
        }
        private static EventResponseDto MapToDto(Event e)
        {
            return new EventResponseDto
            {
                EventId = e.EventId,
                EventName = e.EventName,
                Description = e.Description,
                Location = e.Location,
                EventDate = e.EventDate,
                Capacity = e.Capacity,
                OrganizerId = e.OrganizerId,
                OrganizerName = e.Organizer?.UserName
            };
        }
        public async Task<EventResponseDto> CreateEventAsync(EventCreateDto request, Guid organizerId)
        {
            var EventEntity = new Event
            {
                EventId = Guid.NewGuid(),
                EventName = request.EventName,
                Description = request.Description,
                Location = request.Location,
                EventDate = request.EventDate,
                Capacity = request.Capacity,
                OrganizerId = organizerId,
                CreatedAt = DateTime.UtcNow
            };

            await context.Events.AddAsync(EventEntity);
            await context.SaveChangesAsync();

            return MapToDto(EventEntity);
        }


        public async Task<EventResponseDto?> UpdateEventAsync(Guid id, EventUpdateDto request, Guid userId, string role)
        {
            var EventEntity = await context.Events.FindAsync(id);

            if (EventEntity is null)
                return null;

            if (role == "Organizer" && EventEntity.OrganizerId != userId)
                throw new UnauthorizedAccessException("You cannot modify someone else's event");

            EventEntity.EventName = request.EventName;
            EventEntity.Description = request.Description;
            EventEntity.Location = request.Location;
            EventEntity.EventDate = request.EventDate;
            EventEntity.Capacity = request.Capacity;
            

            await context.SaveChangesAsync();

            return MapToDto(EventEntity);
        }
        public async Task<bool> DeleteEventAsync(Guid id,Guid userId,string role)
        {
            var EventEntity = await context.Events.FindAsync(id);

            if (EventEntity is null)
                return false;

            if (role == "Organizer" && EventEntity.OrganizerId != userId)
                return false;

            context.Events.Remove(EventEntity);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
