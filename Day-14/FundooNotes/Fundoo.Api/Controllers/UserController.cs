using Microsoft.AspNetCore.Mvc;
using FundooNotes.Models.DTOs;
using FundooNotes.Service.Interface;

namespace Fundoo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred during registration.", error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _userService.LoginUserAsync(loginDto);
                if (user == null)
                {
                    return Unauthorized(new { success = false, message = "Invalid email or password." });
                }

                // JWT token is generated in the Service Layer
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
    }
}
