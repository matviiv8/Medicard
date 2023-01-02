using Medicard.Services.ViewModels.Appointment;

namespace Medicard.WebUI.Models
{
    public class ShowAllUserAppointmentsViewModel
    {
        public IEnumerable<AppointmentViewModel> AllAppointments { get; set; }
    }
}
