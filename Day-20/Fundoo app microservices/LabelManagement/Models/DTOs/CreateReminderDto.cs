using System.ComponentModel.DataAnnotations;

namespace LabelManagement.Models.DTOs
{
    public class CreateReminderDto
    {
        [Required(ErrorMessage = "Note ID is required")]
        public int NoteId { get; set; }

        [Required(ErrorMessage = "Reminder time is required")]
        public DateTime ReminderTime { get; set; }
    }
}
