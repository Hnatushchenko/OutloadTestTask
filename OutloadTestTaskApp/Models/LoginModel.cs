using System.ComponentModel.DataAnnotations;

namespace OutloadTestTaskApp.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User name is required")]
        public required string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public required string Password { get; set; }
    }
}
