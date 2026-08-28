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
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        // Helper method to extract userId from JWT token claims
        private int GetCurrentUserId()
        {
            return Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("UserId")?.Value);
        }

        // POST: api/Notes/create
        [HttpPost("create")]
        public async Task<IActionResult> CreateNote([FromBody] CreateNoteDto noteDto)
        {
            int userId = GetCurrentUserId();
            var note = await _noteService.CreateNoteAsync(noteDto, userId);
            return Ok(new { success = true, message = "Note created successfully", data = note });
        }

        // GET: api/Notes/all
        [HttpGet("all")]
        public async Task<IActionResult> GetAllNotes()
        {
            int userId = GetCurrentUserId();
            var notes = await _noteService.GetAllNotesAsync(userId);
            return Ok(new { success = true, message = "Notes retrieved successfully", data = notes });
        }

        // GET: api/Notes/recent - Returns last 5 recently edited notes (from Redis cache)
        [HttpGet("recent")]
        public async Task<IActionResult> GetRecentNotes()
        {
            int userId = GetCurrentUserId();
            var notes = await _noteService.GetRecentNotesAsync(userId);
            return Ok(new { success = true, message = "Recent notes retrieved from cache", data = notes });
        }

        // DELETE: api/Notes/delete/{noteId}
        [HttpDelete("delete/{noteId}")]
        public async Task<IActionResult> DeleteNote(long noteId)
        {
            int userId = GetCurrentUserId();
            var result = await _noteService.DeleteNoteAsync(noteId, userId);
            if (!result)
                return NotFound(new { success = false, message = "Note not found." });

            return Ok(new { success = true, message = "Note deleted successfully" });
        }

        // PUT: api/Notes/pin/{noteId}
        [HttpPut("pin/{noteId}")]
        public async Task<IActionResult> PinNote(long noteId)
        {
            int userId = GetCurrentUserId();
            var result = await _noteService.PinNoteAsync(noteId, userId);
            if (!result)
                return NotFound(new { success = false, message = "Note not found." });

            return Ok(new { success = true, message = "Note pin status updated" });
        }

        // PUT: api/Notes/archive/{noteId}
        [HttpPut("archive/{noteId}")]
        public async Task<IActionResult> ArchiveNote(long noteId)
        {
            int userId = GetCurrentUserId();
            var result = await _noteService.ArchiveNoteAsync(noteId, userId);
            if (!result)
                return NotFound(new { success = false, message = "Note not found." });

            return Ok(new { success = true, message = "Note archive status updated" });
        }

        // PUT: api/Notes/trash/{noteId}
        [HttpPut("trash/{noteId}")]
        public async Task<IActionResult> TrashNote(long noteId)
        {
            int userId = GetCurrentUserId();
            var result = await _noteService.TrashNoteAsync(noteId, userId);
            if (!result)
                return NotFound(new { success = false, message = "Note not found." });

            return Ok(new { success = true, message = "Note trash status updated" });
        }

        // GET: api/Notes/search?title=meeting
        [HttpGet("search")]
        public async Task<IActionResult> SearchNotes(string title)
        {
            int userId = GetCurrentUserId();
            var notes = await _noteService.SearchNotesByTitleAsync(title, userId);
            return Ok(new { success = true, message = "Notes retrieved successfully", data = notes });
        }

        // GET: api/Notes/pinned
        [HttpGet("pinned")]
        public async Task<IActionResult> GetPinnedNotes()
        {
            int userId = GetCurrentUserId();
            var notes = await _noteService.GetPinnedNotesAsync(userId);
            return Ok(new { success = true, message = "Pinned notes retrieved successfully", data = notes });
        }

        // GET: api/Notes/archived
        [HttpGet("archived")]
        public async Task<IActionResult> GetArchivedNotes()
        {
            int userId = GetCurrentUserId();
            var notes = await _noteService.GetArchivedNotesAsync(userId);
            return Ok(new { success = true, message = "Archived notes retrieved successfully", data = notes });
        }

        // GET: api/Notes/trash
        [HttpGet("trash")]
        public async Task<IActionResult> GetTrashNotes()
        {
            int userId = GetCurrentUserId();
            var notes = await _noteService.GetTrashNotesAsync(userId);
            return Ok(new { success = true, message = "Trash notes retrieved successfully", data = notes });
        }
    }
}
