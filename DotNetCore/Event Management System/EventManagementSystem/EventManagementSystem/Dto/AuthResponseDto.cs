namespace EventManagementSystem.Dto
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}
