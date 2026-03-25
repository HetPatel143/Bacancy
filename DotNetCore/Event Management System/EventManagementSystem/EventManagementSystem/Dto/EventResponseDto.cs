namespace EventManagementSystem.Dto
{
    public class EventResponseDto
    {
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime EventDate { get; set; }
        public int Capacity { get; set; }
        public Guid OrganizerId { get; set; }
        public string OrganizerName { get; set; }
    }
}
