namespace EventManagementSystem.Dto
{
    public class EventUpdateDto
    {
        public string EventName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime EventDate { get; set; }
        public int Capacity { get; set; }
    }
}
