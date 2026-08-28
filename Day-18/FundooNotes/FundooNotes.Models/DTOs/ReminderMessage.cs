namespace FundooNotes.Models.DTOs
{
    public class ReminderMessage
    {
        public int ReminderId { get; set; }
        public int NoteId { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public DateTime ReminderTime { get; set; }
        public string NoteTitle { get; set; } = string.Empty;
    }
}
