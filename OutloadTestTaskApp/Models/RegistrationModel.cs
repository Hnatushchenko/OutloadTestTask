using System.ComponentModel.DataAnnotations;

namespace OutloadTestTaskApp.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "User name is required")]
        public required string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public required string Password { get; set; }
    }
}
