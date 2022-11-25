using Medicard.Domain.Entities;
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

        public string ImagePath { get; set; }
    }
}
