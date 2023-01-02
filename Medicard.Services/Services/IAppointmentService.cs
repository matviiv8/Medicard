using Medicard.Domain.Entities;
using Medicard.Services.ViewModels.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services
{
    public interface IAppointmentService
    {
        AppointmentViewModel FillAppointViewModel(string doctorId);

        IEnumerable<string> GetDoctorWorkHoursByDoctorId(int id);

        bool IsDoctorFreeOnDateAnHourAsync(AppointmentViewModel model);

        Task CreateAppointment(Patient patient, Doctor doctor, AppointmentViewModel model);

        IEnumerable<AppointmentViewModel> GetAllAppointments();

        void DeleteAppointment(int id);

        Appointment GetAppointment(string userId, AppointmentViewModel model);

        Appointment GetByDoctorId(int doctorId);

        bool IsUserFreeOnDateAnHourAsync(string userId, AppointmentViewModel model);
    }
}
