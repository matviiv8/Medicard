﻿using Medicard.Domain.Astract;
using Medicard.Domain.Astract.Repositories;
using Medicard.Domain.Concrete;
using Medicard.Domain.Entities;
using Medicard.Services.ViewModels.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
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
