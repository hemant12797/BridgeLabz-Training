using FundooNotes.Models;
using FundooNotes.Models.DTOs;

namespace FundooNotes.Service.Interface
{
    public interface IUserService
    {
        Task<User> RegisterUserAsync(UserRegistrationDto registerDto);
        Task<User?> LoginUserAsync(UserLoginDto loginDto);
        string GenerateJwtToken(User user);
    }
}
