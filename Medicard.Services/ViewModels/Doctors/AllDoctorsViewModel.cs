using Medicard.Domain.Entities;

namespace Medicard.Services.ViewModels.Doctors
{
    public class AllDoctorsViewModel
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string Specialty { get; set; }

        public string ContactNumber { get; set; }

        public string ImagePath { get; set; }
    }
}
