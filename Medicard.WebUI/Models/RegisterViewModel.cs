using Medicard.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Medicard.WebUI.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string PasswordConfirm { get; set; }

    }
}
