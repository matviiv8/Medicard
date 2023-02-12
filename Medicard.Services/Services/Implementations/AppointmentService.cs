using Medicard.Domain.Astract;
using Medicard.Domain.Entities;
using Medicard.Services.Services.Interfaces;
using Medicard.Services.ViewModels.Appointment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
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
            var doctor = _unitOfWork.GenericRepository<Doctor>().GetAll(doctor => doctor.UserId == doctorId).FirstOrDefault();
            var institution = _unitOfWork.GenericRepository<Institution>().GetById(doctor.InstitutionId);

            var appointmentViewModel = new AppointmentViewModel()
            {
                DoctorId = doctor.Id,
                DoctorFullName = doctor.ToString(),
                WorkHours = GetDoctorWorkHoursByDoctorId(doctor.Id),
                ProfileImage = doctor.DoctorPicture,
                Specialization = doctor.Specialization,
                DoctorConctactNumber = doctor.ContactNumber,
            };

            if (institution != null)
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
                        DoctorFullName = doctor.ToString(),
                        DoctorId = appointment.DoctorId,
                        PatientId = appointment.PatientId,
                        ProfileImage = doctor.DoctorPicture,
                        Specialization = doctor.Specialization,
                        Date = appointment.Date.ToString("dd.MM.yyyy"),
                        Time = appointment.Time.ToString("HH:mm"),
                        DoctorConctactNumber = doctor.ContactNumber,
                        PatientFullName = patient.ToString(),
                    };

                    if (institution != null)
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
            return _unitOfWork.GenericRepository<Appointment>().GetAll(appointment => appointment.DoctorId == doctorId).FirstOrDefault();
        }
        public Appointment GetAppointment(string userId, AppointmentViewModel model)
        {
            var date = DateTime.ParseExact(model.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var time = DateTime.ParseExact(model.Time, "HH:mm", CultureInfo.InvariantCulture);
            var patient = _unitOfWork.GenericRepository<Patient>().GetAll().Where(patient => patient.UserId == userId).FirstOrDefault();

            return _unitOfWork.GenericRepository<Appointment>().GetAll(appointment => appointment.PatientId == patient.Id && appointment.Date == date && appointment.Time == time)
                .FirstOrDefault();
        }

        public IEnumerable<string> GetDoctorWorkHoursByDoctorId(int id)
        {
            var doctor = _unitOfWork.GenericRepository<Doctor>().GetById(id);
            var workHours = _unitOfWork.GenericRepository<WorkHour>().GetAll(hour => hour.ScheduleId == doctor.ScheduleId).Select(hour => hour.Hour);
            var doctorWorkHours = new List<string>();
            var institution = _unitOfWork.GenericRepository<Institution>().GetById(doctor.InstitutionId);

            if (institution != null)
            {
                foreach (var hour in workHours)
                {
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

        public bool IsUserFreeOnDateAnHourAsync(string userId, AppointmentViewModel model)
        {
            var date = DateTime.ParseExact(model.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var time = DateTime.ParseExact(model.Time, "HH:mm", CultureInfo.InvariantCulture);
            var patient = _unitOfWork.GenericRepository<Patient>().GetAll(patient => patient.UserId == userId).FirstOrDefault();

            return _unitOfWork.GenericRepository<Appointment>().GetAll()
                .Where(e => e.PatientId == patient.Id)
                .Where(d => d.Date == date && d.Time == time)
                .FirstOrDefault() == null;
        }

        public bool IsDoctorFreeOnDateAnHourAsync(AppointmentViewModel model)
        {
            var date = DateTime.ParseExact(model.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var time = DateTime.ParseExact(model.Time, "HH:mm", CultureInfo.InvariantCulture);

            return _unitOfWork.GenericRepository<Appointment>().GetAll(appointment => appointment.DoctorId == model.DoctorId && appointment.Date == date && appointment.Time == time)
                .FirstOrDefault() == null;
        }
    }
}
