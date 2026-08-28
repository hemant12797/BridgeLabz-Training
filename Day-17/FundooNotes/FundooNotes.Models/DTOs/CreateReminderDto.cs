using System.ComponentModel.DataAnnotations;

namespace FundooNotes.Models.DTOs
{
    public class CreateReminderDto
    {
        [Required]
        public int NoteId { get; set; }

        [Required]
        public DateTime ReminderTime { get; set; }
    }
}
