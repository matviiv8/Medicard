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

        IEnumerable<string> GetDoctorWorkHoursByDoctorId(string doctorId);

        Task CreateAppointment(Patient patient, Doctor doctor, AppointmentViewModel model);
        IEnumerable<AppointmentViewModel> GetAllAppointments();
        void DeleteAppointment(int id);
        Appointment GetByDoctorId(int doctorId);
    }
}
