using Medicard.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Medicard.Services.ViewModels
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
        public Medicard.Domain.Entities.Enums.Gender Gender { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string PasswordConfirm { get; set; }

    }
}
