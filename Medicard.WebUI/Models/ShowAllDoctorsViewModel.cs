using Medicard.Services.ViewModels.Doctor;

namespace Medicard.WebUI.Models
{
    public class ShowAllDoctorsViewModel
    {
        public IEnumerable<AllDoctorsViewModel> AllDoctors { get; set; }

        public PageViewModel PagingInfo { get; set; }

        public IEnumerable<string> Specializations { get; set; } = new List<string>();

        public IEnumerable<string> Institutions { get; set; } = new List<string>();
    }
}
