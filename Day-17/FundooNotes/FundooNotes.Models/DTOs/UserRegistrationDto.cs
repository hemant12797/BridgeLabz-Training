using System.ComponentModel.DataAnnotations;

namespace FundooNotes.Models.DTOs
{
    public class UserRegistrationDto
    {

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
