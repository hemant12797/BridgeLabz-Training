using System.ComponentModel.DataAnnotations;

namespace FundooNotes.Models.DTOs
{
    public class CreateReminderDto
    {
        [Required(ErrorMessage = "NoteId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "NoteId must be greater than 0")]
        public int NoteId { get; set; }

        [Required(ErrorMessage = "ReminderTime is required")]
        public DateTime ReminderTime { get; set; }
    }
}
