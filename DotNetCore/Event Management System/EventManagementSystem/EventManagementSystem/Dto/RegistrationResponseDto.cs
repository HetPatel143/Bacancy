using EventManagementSystem.Models;

namespace EventManagementSystem.Dto
{
    public class RegistrationResponseDto
    {
        public Guid RegistrationId { get; set; }
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public RegistrationStatus Status { get; set; }
    }
}
