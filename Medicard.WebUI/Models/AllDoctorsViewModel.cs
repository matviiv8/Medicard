using Medicard.Domain.Entities;

namespace Medicard.WebUI.Models
{
    public class AllDoctorsViewModel
    {
        public IEnumerable<Doctor>? Doctors { get; set; }
    }
}
