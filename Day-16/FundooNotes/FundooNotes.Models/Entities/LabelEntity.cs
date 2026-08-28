using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundooNotes.Models.Entities
{
    public class LabelEntity
    {
        [Key]
        public int LabelId { get; set; }

        [Required]
        [MaxLength(50)]
        public string LabelName { get; set; } = string.Empty;

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Note")]
        public int NoteId { get; set; }
    }
}
