using EventManagementSystem.Data;
using EventManagementSystem.Dto;
using EventManagementSystem.Interfaces;
using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Services
{
    public class RegistrationService(AppDbContext context) : IRegistrationService
    {
        public async Task<bool> RegisterForEventAsync(Guid userId, Guid eventId)
        {
            var eventEntity = await context.Events.FindAsync(eventId);

            if (eventEntity == null)
                throw new InvalidOperationException("Event not found");


            var registration = await context.Registrations
                .FirstOrDefaultAsync(e => e.UserId == userId && e.EventId == eventId);

            if (registration != null)
            {
                if (registration.Status == RegistrationStatus.Registered)
                    throw new InvalidOperationException("Already registered");

                registration.Status = RegistrationStatus.Registered;
                await context.SaveChangesAsync();
                return true;
            }
            var count = await context.Registrations.CountAsync(r => r.EventId == eventId
                && r.Status == RegistrationStatus.Registered);

            if (count >= eventEntity.Capacity)
                throw new InvalidOperationException("Event is full");


            var newregistration = new Registration
            {
                RegistrationId = Guid.NewGuid(),
                UserId = userId,
                EventId = eventId,
                RegisteredAt = DateTime.UtcNow,
                Status = RegistrationStatus.Registered
            };

            context.Registrations.Add(newregistration);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> CancelRegistrationAsync(Guid userId, Guid eventId)
        {
            var exist = await context.Registrations.FirstOrDefaultAsync(e => e.UserId == userId && e.EventId == eventId);
            if (exist is null)
                return false;

            if (exist.Status == RegistrationStatus.Cancelled)
                return false;
            exist.Status = RegistrationStatus.Cancelled;
            
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<EventResponseDto>> GetUserRegistrationAsync(Guid userId)
        {
            context.Events.Include(e => e.Organizer);
            return await context.Registrations.Where(e => e.UserId == userId
            && e.Status == RegistrationStatus.Registered).Select(e => new EventResponseDto
                {
                    EventId = e.Event.EventId,
                    EventName = e.Event.EventName,
                    Description = e.Event.Description,
                    Location = e.Event.Location,
                    EventDate = e.Event.EventDate,
                    Capacity = e.Event.Capacity,
                    OrganizerId = e.Event.OrganizerId,
                    OrganizerName = e.Event.Organizer.UserName
            }).ToListAsync();
        }
        public async Task<IEnumerable<RegistrationResponseDto>> GetRegistrationsForOrganizerAsync(Guid organizerId)
        {
            var registrations = await context.Registrations
                .Include(r => r.Event)
                .Include(r => r.User)
                .Where(r => r.Event.OrganizerId == organizerId)
                .ToListAsync();

            return registrations.Select(r => new RegistrationResponseDto
            {
                RegistrationId = r.RegistrationId,
                EventId = r.EventId,
                EventName = r.Event.EventName,
                UserId = r.UserId,
                UserName = r.User.UserName,
                Status = r.Status
            });
        }
        public async Task<IEnumerable<RegistrationResponseDto>> GetAllRegistrationsAsync()
        {
            var registrations = await context.Registrations
                .Include(r => r.Event)
                .Include(r => r.User)
                .ToListAsync();

            return registrations.Select(r => new RegistrationResponseDto
            {
                RegistrationId = r.RegistrationId,
                EventId = r.EventId,
                EventName = r.Event.EventName,
                UserId = r.UserId,
                UserName = r.User.UserName,
                Status = r.Status
            });
        }

    }
}
