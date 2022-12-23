using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.ViewModels
{
    public class RegisterExternalViewModel
    { 
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string? ReturnUrl { get; set; }

        public Medicard.Domain.Entities.Enums.Gender Gender { get; set; }

        public string? LoginProvider { get; set; }

    }
}
