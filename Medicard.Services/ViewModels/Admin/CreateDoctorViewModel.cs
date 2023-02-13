using Medicard.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.ViewModels.Admin
{
    public class CreateDoctorViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public bool IsHeadDoctor { get; set; } = false;

        public string? Specialization { get; set; }

        public string? ContactNumber { get; set; }

        public bool IsPaid { get; set; } = false;

        public decimal ServicePrice { get; set; }
    }
}
