using FundooNotes.UserManagement.DTOs;
using FundooNotes.UserManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace FundooNotes.UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: api/user/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto dto)
        {
            var user = await _userService.RegisterAsync(dto);
            if (user == null)
            {
                return BadRequest("User with this email already exists.");
            }

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, new { user.Id, user.FirstName, user.LastName, user.Email });
        }

        // POST: api/user/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            var token = await _userService.LoginAsync(dto);
            if (token == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok(new { Token = token });
        }

        // POST: api/user/forgot-password
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] string email)
        {
            var result = await _userService.ForgotPasswordAsync(email);
            if (!result)
            {
                return NotFound("User not found.");
            }

            return Ok("Password reset link sent to your email.");
        }

        // PUT: api/user/reset-password
        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword([FromQuery] string email, [FromBody] string newPassword)
        {
            var result = await _userService.ResetPasswordAsync(email, newPassword);
            if (!result)
            {
                return NotFound("User not found.");
            }

            return Ok("Password has been reset successfully.");
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(new { user.Id, user.FirstName, user.LastName, user.Email });
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
