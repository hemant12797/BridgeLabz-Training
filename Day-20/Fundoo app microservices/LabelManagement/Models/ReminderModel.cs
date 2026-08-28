using System.ComponentModel.DataAnnotations;

namespace LabelManagement.Models
{
    public class ReminderModel
    {
        [Key]
        public int ReminderId { get; set; }

        [Required]
        public int NoteId { get; set; }

        [Required]
        public DateTime ReminderTime { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
