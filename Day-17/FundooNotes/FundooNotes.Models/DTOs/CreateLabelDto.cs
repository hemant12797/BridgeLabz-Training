using System.ComponentModel.DataAnnotations;

namespace FundooNotes.Models.DTOs
{
    public class CreateLabelDto
    {
        [Required]
        [MaxLength(50)]
        public string LabelName { get; set; } = string.Empty;

        public int NoteId { get; set; }
    }
}
