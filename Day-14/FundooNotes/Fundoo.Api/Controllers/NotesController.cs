using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FundooNotes.Models.DTOs;
using FundooNotes.Service.Interface;

namespace Fundoo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]   // all endpoints in this controller require a valid JWT
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        // Helper: extract the logged-in user's ID from JWT claims
        private int GetCurrentUserId()
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.TryParse(claim, out var id) ? id : 0;
        }

        // POST api/Notes/create
        [HttpPost("create")]
        public async Task<IActionResult> CreateNote([FromBody] CreateNoteDto noteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var userId = GetCurrentUserId();
                var note = await _noteService.CreateNoteAsync(noteDto, userId);
                return Ok(new
                {
                    success = true,
                    message = "Note created successfully",
                    data = note
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Error creating note.", error = ex.Message });
            }
        }

        // GET api/Notes/all
        [HttpGet("all")]
        public async Task<IActionResult> GetAllNotes()
        {
            try
            {
                var userId = GetCurrentUserId();
                var notes = await _noteService.GetAllNotesAsync(userId);
                return Ok(new
                {
                    success = true,
                    message = "Notes retrieved successfully",
                    data = notes
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Error retrieving notes.", error = ex.Message });
            }
        }

        // DELETE api/Notes/delete/{noteId}
        [HttpDelete("delete/{noteId}")]
        public async Task<IActionResult> DeleteNote(long noteId)
        {
            try
            {
                var userId = GetCurrentUserId();
                var deleted = await _noteService.DeleteNoteAsync(noteId, userId);

                if (!deleted)
                    return NotFound(new { success = false, message = "Note not found or you do not have permission to delete it." });

                return Ok(new { success = true, message = "Note deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Error deleting note.", error = ex.Message });
            }
        }
    }
}
