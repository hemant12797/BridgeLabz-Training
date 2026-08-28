using System.ComponentModel.DataAnnotations;

namespace FundooNotes.Models.DTOs
{
    public class UpdateLabelDto
    {
        [Required]
        [MaxLength(50)]
        public string LabelName { get; set; } = string.Empty;
    }
}
