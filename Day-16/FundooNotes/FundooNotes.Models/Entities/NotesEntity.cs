using System.ComponentModel.DataAnnotations;

namespace FundooNotes.Models.Entities
{
    // db table structure for notes
    public class NotesEntity
    {
        [Key]
        public long NoteId { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public DateTime? Reminder { get; set; }

        [MaxLength(20)]
        public string Backgroundcolor { get; set; }

        [MaxLength(200)]
        public string Image { get; set; }

        public bool Pin { get; set; }
        public bool Archive { get; set; }
        public bool Trash { get; set; }

        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }

        // links note to the user who owns it
        public int UserId { get; set; }
    }
}
