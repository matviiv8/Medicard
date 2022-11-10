﻿using Medicard.Domain.Entities.Enums;

namespace Medicard.WebUI.Models
{
    public class PatientProfileViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? ContactNumber { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public string? Address { get; set; }

        public string? BirthDate { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

    }
}
