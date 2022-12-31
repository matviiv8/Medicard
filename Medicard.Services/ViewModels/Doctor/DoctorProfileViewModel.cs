using Medicard.Domain.Entities.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.ViewModels.Doctor
{
    public class DoctorProfileViewModel
    {
        public string Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? ContactNumber { get; set; }

        public IFormFile DoctorPicture { get; set; }

        public string PictureName { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public string? Specialization { get; set; }
        
        public string Institution { get; set; }

    }
}
