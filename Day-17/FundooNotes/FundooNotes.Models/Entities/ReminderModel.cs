using System.ComponentModel.DataAnnotations;

namespace FundooNotes.Models.Entities
{
    public class ReminderModel
    {
        [Key]
        public int ReminderId { get; set; }
        public int NoteId { get; set; }
        public DateTime ReminderTime { get; set; }
        public int UserId { get; set; }
    }
}
