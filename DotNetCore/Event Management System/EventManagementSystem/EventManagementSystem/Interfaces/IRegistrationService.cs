using EventManagementSystem.Dto;

namespace EventManagementSystem.Interfaces
{
    public interface IRegistrationService
    {
        Task<bool> RegisterForEventAsync(Guid userId, Guid eventId);
        Task<bool> CancelRegistrationAsync(Guid userId, Guid eventId);
        Task<IEnumerable<EventResponseDto>> GetUserRegistrationAsync(Guid userId);
        Task<IEnumerable<RegistrationResponseDto>> GetRegistrationsForOrganizerAsync(Guid organizerId);
        Task<IEnumerable<RegistrationResponseDto>> GetAllRegistrationsAsync();

    }
}
