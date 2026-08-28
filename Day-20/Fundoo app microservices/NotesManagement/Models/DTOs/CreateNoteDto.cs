using System.ComponentModel.DataAnnotations;

namespace NotesManagement.Models.DTOs
{
    public class CreateNoteDto
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 100 characters")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "Background color cannot exceed 20 characters")]
        public string Backgroundcolor { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Image URL cannot exceed 200 characters")]
        public string Image { get; set; } = string.Empty;

        public bool Pin { get; set; }
        public bool Archive { get; set; }
    }
}
