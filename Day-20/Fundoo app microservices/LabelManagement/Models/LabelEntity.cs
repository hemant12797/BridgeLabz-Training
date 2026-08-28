using System.ComponentModel.DataAnnotations;

namespace LabelManagement.Models
{
    public class LabelEntity
    {
        [Key]
        public int LabelId { get; set; }

        [Required]
        [MaxLength(50)]
        public string LabelName { get; set; } = string.Empty;

        public int UserId { get; set; }

        public int NoteId { get; set; }
    }
}
