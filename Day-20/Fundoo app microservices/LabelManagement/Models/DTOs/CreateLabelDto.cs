using System.ComponentModel.DataAnnotations;

namespace LabelManagement.Models.DTOs
{
    public class CreateLabelDto
    {
        [Required(ErrorMessage = "Label name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Label name must be between 1 and 50 characters")]
        public string LabelName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Note ID is required")]
        public int NoteId { get; set; }
    }
}
