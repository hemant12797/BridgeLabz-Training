using UserRegistrationAPI.Models;

namespace UserRegistrationAPI.Services
{
    public interface IUserService
    {
        Task<string> RegisterUser(RegisterModel model);
    }
}
