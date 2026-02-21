using Microsoft.AspNetCore.Identity;
using UserRegistrationAPI.Models;

namespace UserRegistrationAPI.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> RegisterUser(RegisterModel model)
        {
            var user = new ApplicationUser
            {
                FullName = model.FullName,
                Email = model.Email,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
                return "User Registered Successfully";

            return string.Join(", ", result.Errors.Select(e => e.Description));
        }
    }
}
