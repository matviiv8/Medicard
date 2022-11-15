using Medicard.Domain.Entities;

namespace Medicard.Services.ViewModels
{
    public class AllDoctorsViewModel
    {
        public IEnumerable<Doctor>? Doctors { get; set; }
    }
}
