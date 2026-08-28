using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundooNotes.Models.Entities
{
    // db table structure for notes
    public class NotesEntity
    {
        [Key]
        public long NoteId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Backgroundcolor { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Image { get; set; } = string.Empty;

        public bool Pin { get; set; }
        public bool Archive { get; set; }
        public bool Trash { get; set; }

        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }

        // links note to the user who owns it
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
