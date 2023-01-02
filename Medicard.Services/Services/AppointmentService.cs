using Medicard.Domain.Astract;
using Medicard.Domain.Entities;
using Medicard.Services.ViewModels.Appointment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAppointment(Patient patient, Doctor doctor, AppointmentViewModel model)
        {
            var appointment = new Appointment
            {
                PatientId = patient.Id,
                DoctorId = doctor.Id,
                Date = DateTime.ParseExact(model.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture),
                Time = DateTime.ParseExact(model.Time, "HH:mm", CultureInfo.InvariantCulture),
            };

            _unitOfWork.GenericRepository<Appointment>().Add(appointment);
            await _unitOfWork.SaveAsync();
        }

        public async void DeleteAppointment(int id)
        {
            var appointment = _unitOfWork.GenericRepository<Appointment>().GetById(id);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7015/api/");
                var deleteTask = client.DeleteAsync("Appointment/" + appointment.Id);
                deleteTask.Wait();
            }

            await _unitOfWork.SaveAsync();
        }

        public AppointmentViewModel FillAppointViewModel(string doctorId)
        {
            var doctor = _unitOfWork.GenericRepository<Doctor>().GetAll().Where(doctor => doctor.UserId == doctorId).FirstOrDefault();
            var institution = _unitOfWork.GenericRepository<Institution>().GetById(doctor.InstitutionId);

            var appointmentViewModel = new AppointmentViewModel()
            {
                DoctorId = doctor.Id,
                DoctorFullName = $"{doctor.FirstName} {doctor.LastName}",
                WorkHours = GetDoctorWorkHoursByDoctorId(doctorId),
                ProfileImage = doctor.DoctorPicture,
                Specialization = doctor.Specialization,
                DoctorConctactNumber = doctor.ContactNumber,
            };
            
            if(institution != null)
            {
                appointmentViewModel.InstitutionName = institution.Name;
                appointmentViewModel.InstitutionAddress = institution.Address;
            }

            return appointmentViewModel;
        }

        public IEnumerable<AppointmentViewModel> GetAllAppointments()
        {
            var appointments = new List<AppointmentViewModel>();
            using (var client = new HttpClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7015/api/Appointment");
                var response = client.SendAsync(requestMessage).Result;
                var data = response.Content.ReadAsAsync<List<Appointment>>().Result;

                foreach (var appointment in data)
                {
                    var doctor = _unitOfWork.GenericRepository<Doctor>().GetById(appointment.DoctorId);
                    var institution = _unitOfWork.GenericRepository<Institution>().GetById(doctor.InstitutionId);
                    var patient = _unitOfWork.GenericRepository<Patient>().GetById(appointment.PatientId);

                    var currentAppointment = new AppointmentViewModel
                    {
                        Id = appointment.Id,
                        DoctorFullName = $"{doctor.LastName} {doctor.FirstName}",
                        DoctorId = appointment.DoctorId,
                        PatientId = appointment.PatientId,
                        ProfileImage = doctor.DoctorPicture,
                        Specialization = doctor.Specialization,
                        Date = appointment.Date.ToString("dd.MM.yyyy"),
                        Time = appointment.Time.ToString("HH:mm"),
                        DoctorConctactNumber = doctor.ContactNumber,
                        PatientFullName = $"{patient.LastName} {patient.FirstName}"
                    };

                    if(institution != null)
                    {
                        currentAppointment.InstitutionName = institution.Name;
                        currentAppointment.InstitutionAddress = institution.Address;
                    }
                    appointments.Add(currentAppointment);
                }
            }
            return appointments;
        }

        public Appointment GetByDoctorId(int doctorId)
        {
            return _unitOfWork.GenericRepository<Appointment>().GetAll().Where(appointment => appointment.DoctorId == doctorId).FirstOrDefault();
        }

        public IEnumerable<string> GetDoctorWorkHoursByDoctorId(string doctorId)
        {
            var doctor = _unitOfWork.GenericRepository<Doctor>().GetAll().Where(doctor => doctor.UserId == doctorId).FirstOrDefault();
            var institution = _unitOfWork.GenericRepository<Institution>().GetById(doctor.InstitutionId);
            var workHours = _unitOfWork.GenericRepository<WorkHour>().GetAll().Where(hour => hour.ScheduleId == doctor.ScheduleId).Select(hour => hour.Hour);
            var doctorWorkHours = new List<string>();

            if(institution != null)
            {
                foreach(var hour in workHours) {
                    if (DateTime.ParseExact(hour, "HH:mm", CultureInfo.InvariantCulture) >= DateTime.ParseExact(institution.WorkScheduleWeekdayStart, "HH:mm", CultureInfo.InvariantCulture)
                        && DateTime.ParseExact(hour, "HH:mm", CultureInfo.InvariantCulture) <= DateTime.ParseExact(institution.WorkScheduleWeekdayEnd, "HH:mm", CultureInfo.InvariantCulture))
                    {
                        doctorWorkHours.Add(hour);
                    }
                }

                return doctorWorkHours;
            }
            else
            {
                return workHours;
            }
        }

    }
}
