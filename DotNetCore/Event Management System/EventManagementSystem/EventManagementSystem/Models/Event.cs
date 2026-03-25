namespace EventManagementSystem.Models
{
    public class Event
    {
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime EventDate { get; set; }
        public int Capacity { get; set; }
        public Guid OrganizerId { get; set; }
        public DateTime CreatedAt { get; set; }

        public User? Organizer { get; set; }
        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
