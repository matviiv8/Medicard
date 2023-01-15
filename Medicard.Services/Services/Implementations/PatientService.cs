using Medicard.Domain.Astract;
using Medicard.Domain.Astract.Repositories;
using Medicard.Domain.Concrete;
using Medicard.Domain.Entities;
using Medicard.Services.Services.Interfaces;
using Medicard.Services.ViewModels.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<AllPatientsViewModel> AllPatients()
        {
            var patients = new List<AllPatientsViewModel>();
            using (var client = new HttpClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7015/api/Patient");
                var response = client.SendAsync(requestMessage).Result;
                var data = response.Content.ReadAsAsync<List<Patient>>().Result;
                foreach (var patient in data)
                {
                    var personalDoctor = _unitOfWork.GenericRepository<Doctor>().GetById(patient.DoctorId);
                    var patientInfo = new AllPatientsViewModel
                    {
                        Id = patient.UserId,
                        FullName = patient.ToString(),
                        Address = patient.Address,
                        ContactNumber = patient.ContactNumber,
                        BirthDate = patient.BirthDate,
                    };

                    if (personalDoctor != null)
                    {
                        patientInfo.PersonalDoctorFullName = personalDoctor.ToString();
                    }

                    patients.Add(patientInfo);
                }
            }
            return patients;
        }

        public async Task AppointPersonalDoctor(Patient patient, string doctorsUserId)
        {
            var doctor = _unitOfWork.GenericRepository<Doctor>().GetAll().Where(doctor => doctor.UserId == doctorsUserId).FirstOrDefault();
            patient.DoctorId = doctor.Id;
            _unitOfWork.GenericRepository<Patient>().Update(patient);
            await _unitOfWork.SaveAsync();
        }

        public async Task ChangePatient(PatientProfileViewModel model, string userId)
        {
            var patient = _unitOfWork.GenericRepository<Patient>().GetAll().FirstOrDefault(d => d.UserId == userId);

            patient.FirstName = model.FirstName;
            patient.LastName = model.LastName;
            patient.BirthDate = model.BirthDate;
            patient.Address = model.Address;
            patient.Age = model.Age;
            patient.ContactNumber = model.ContactNumber;
            patient.Gender = model.Gender;
            patient.MaritalStatus = model.MaritalStatus;

            _unitOfWork.GenericRepository<Patient>().Update(patient);
            await _unitOfWork.SaveAsync();
        }

        public Patient GetByUserId(string userId)
        {
            return _unitOfWork.GenericRepository<Patient>().GetAll().Where(patient => patient.UserId == userId).FirstOrDefault();
        }

        public PatientProfileViewModel ViewProfile(string userId)
        {
            var patient = _unitOfWork.GenericRepository<Patient>().GetAll().FirstOrDefault(d => d.UserId == userId);

            var patientInfo = new PatientProfileViewModel
            {
                Id = patient.UserId,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                BirthDate = patient.BirthDate,
                Address = patient.Address,
                Age = patient.Age,
                ContactNumber = patient.ContactNumber,
                Gender = patient.Gender,
                MaritalStatus = patient.MaritalStatus,
            };

            return patientInfo;
        }
    }
}
