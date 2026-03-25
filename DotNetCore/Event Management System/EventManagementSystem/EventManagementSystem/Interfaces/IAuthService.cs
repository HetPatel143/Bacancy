using EventManagementSystem.Dto;
using EventManagementSystem.Models;

namespace EventManagementSystem.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(UserRegistrationDto request);
        Task<AuthResponseDto> LoginAsync(UserLoginDto request);
    }
}
