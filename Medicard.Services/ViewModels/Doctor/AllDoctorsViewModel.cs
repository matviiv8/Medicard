﻿using Medicard.Domain.Entities;
using Medicard.Domain.Entities.Enums;

namespace Medicard.Services.ViewModels.Doctor
{
    public class AllDoctorsViewModel
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string Specialization { get; set; }
        
        public Gender Gender { get; set; }

        public string ContactNumber { get; set; }

        public string Image { get; set; }

        public string UserName { get; set; }

        public string Institution { get; set; }

        public bool IsHeadDoctor { get; set; } = false;

        public bool IsPaid { get; set; } = false;

        public decimal ServicePrice { get; set; }
    }
}
