using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundooNotes.Models.Entities
{
    public class ReminderModel
    {
        [Key]
        public int ReminderId { get; set; }

        [Required]
        [ForeignKey("Note")]
        public int NoteId { get; set; }

        [Required]
        public DateTime ReminderTime { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
