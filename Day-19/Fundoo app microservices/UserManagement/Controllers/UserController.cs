using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Models.DTOs;
using UserManagement.Repositories;
using UserManagement.Services;

namespace UserManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public UserController(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto registerDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var user = await _userService.RegisterUserAsync(registerDto);
                return Ok(new
                {
                    success = true,
                    message = "User registered successfully",
                    data = new { user.UserId, user.FirstName, user.LastName, user.Email }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred during registration.", error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var user = await _userService.LoginUserAsync(loginDto);
                if (user == null)
                    return Unauthorized(new { success = false, message = "Invalid email or password." });

                var token = _userService.GenerateJwtToken(user);
                return Ok(new
                {
                    success = true,
                    message = "Login successful",
                    token = token,
                    data = new { user.UserId, user.FirstName, user.LastName, user.Email }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred during login.", error = ex.Message });
            }
        }

        // GET: api/User/profile/{userId}
        // Called internally by LabelManagement to get user email for reminder notifications
        [Authorize]
        [HttpGet("profile/{userId}")]
        public async Task<IActionResult> GetProfile(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                return NotFound(new { success = false, message = "User not found." });

            return Ok(new
            {
                success = true,
                message = "User profile retrieved",
                data = new { user.UserId, user.FirstName, user.LastName, user.Email }
            });
        }
    }
}
