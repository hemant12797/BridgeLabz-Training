using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FundooNotes.Models.DTOs;
using FundooNotes.Service.Interface;

namespace Fundoo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ReminderController : ControllerBase
    {
        private readonly IReminderService _reminderService;

        public ReminderController(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        private int GetCurrentUserId()
        {
            return Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("UserId")?.Value);
        }

        // POST: api/Reminder/create
        [HttpPost("create")]
        public async Task<IActionResult> CreateReminder([FromBody] CreateReminderDto reminderDto)
        {
            int userId = GetCurrentUserId();
            var reminder = await _reminderService.CreateReminderAsync(reminderDto, userId);
            return Ok(new { success = true, message = "Reminder created successfully", data = reminder });
        }

        // GET: api/Reminder/{reminderId}
        [HttpGet("{reminderId}")]
        public async Task<IActionResult> GetReminderById(int reminderId)
        {
            int userId = GetCurrentUserId();
            var reminder = await _reminderService.GetReminderByIdAsync(reminderId, userId);
            if (reminder == null)
            {
                return NotFound(new { success = false, message = "Reminder not found." });
            }
            return Ok(new { success = true, message = "Reminder retrieved successfully", data = reminder });
        }

        // GET: api/Reminder/all
        [HttpGet("all")]
        public async Task<IActionResult> GetAllReminders()
        {
            int userId = GetCurrentUserId();
            var reminders = await _reminderService.GetAllRemindersAsync(userId);
            return Ok(new { success = true, message = "Reminders retrieved successfully", data = reminders });
        }

        // DELETE: api/Reminder/delete/{reminderId}
        [HttpDelete("delete/{reminderId}")]
        public async Task<IActionResult> DeleteReminder(int reminderId)
        {
            int userId = GetCurrentUserId();
            var result = await _reminderService.DeleteReminderAsync(reminderId, userId);
            if (!result)
            {
                return NotFound(new { success = false, message = "Reminder not found." });
            }
            return Ok(new { success = true, message = "Reminder deleted successfully" });
        }
    }
}
