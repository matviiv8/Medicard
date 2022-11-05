using Medicard.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Medicard.WebUI.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public int Age { get; set; }
        public Gender Gender { get; set; }
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
