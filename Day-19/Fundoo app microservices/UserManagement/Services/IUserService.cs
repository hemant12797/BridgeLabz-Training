using UserManagement.Models;
using UserManagement.Models.DTOs;

namespace UserManagement.Services
{
    public interface IUserService
    {
        Task<User> RegisterUserAsync(UserRegistrationDto registerDto);
        Task<User?> LoginUserAsync(UserLoginDto loginDto);
        string GenerateJwtToken(User user);
    }
}
