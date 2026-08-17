using FundooNotes.UserManagement.DTOs;
using FundooNotes.UserManagement.Models;

namespace FundooNotes.UserManagement.Services
{
    public interface IUserService
    {
        Task<User?> RegisterAsync(UserRegistrationDto dto);
        Task<string?> LoginAsync(UserLoginDto dto);
        Task<bool> ForgotPasswordAsync(string email);
        Task<bool> ResetPasswordAsync(string email, string newPassword);
        Task<User?> GetUserByIdAsync(int id);
        Task<bool> DeleteUserAsync(int id);
    }
}
