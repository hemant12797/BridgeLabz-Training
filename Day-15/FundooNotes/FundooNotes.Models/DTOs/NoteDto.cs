using System.ComponentModel.DataAnnotations;

namespace FundooNotes.Models.DTOs
{
    // DTO used when creating a new note
    public class CreateNoteDto
    {
        [Required, MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public DateTime? Reminder { get; set; }

        [MaxLength(20)]
        public string Backgroundcolor { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Image { get; set; } = string.Empty;

        public bool Pin { get; set; }
        public bool Archive { get; set; }
    }
}
