namespace EventManagementSystem.Models
{
    public class Registration
    {
        public Guid RegistrationId { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
        public DateTime RegisteredAt { get; set; }
        public RegistrationStatus Status { get; set; }
        public User? User { get; set; }
        public Event? Event { get; set; }

    }
}
