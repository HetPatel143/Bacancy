using EventManagementSystem.Dto;

namespace EventManagementSystem.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventResponseDto>> GetAllAsync();
        Task<EventResponseDto?> GetEventByIdAsync(Guid id);
        Task<EventResponseDto> CreateEventAsync(EventCreateDto request, Guid organizerId);
        Task<EventResponseDto?> UpdateEventAsync(Guid id,EventUpdateDto request,Guid userId,string role);
        Task<bool> DeleteEventAsync(Guid id, Guid userId, string role);

    }
}
