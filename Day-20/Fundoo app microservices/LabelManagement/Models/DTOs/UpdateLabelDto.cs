using System.ComponentModel.DataAnnotations;

namespace LabelManagement.Models.DTOs
{
    public class UpdateLabelDto
    {
        [Required(ErrorMessage = "Label name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Label name must be between 1 and 50 characters")]
        public string LabelName { get; set; } = string.Empty;
    }
}
