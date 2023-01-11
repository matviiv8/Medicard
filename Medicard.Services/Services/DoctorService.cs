using Medicard.Domain.Astract;
using Medicard.Domain.Concrete;
using Medicard.Domain.Entities;
using Medicard.Services.ViewModels.Doctor;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http.Formatting;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Medicard.WebAPI.Controllers;

namespace Medicard.Services.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DoctorService(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            this._unitOfWork = unitOfWork;
            this._webHostEnvironment = webHostEnvironment;
        }

        public IEnumerable<AllDoctorsViewModel> AllDoctors()
        {
            var doctors = new List<AllDoctorsViewModel>();
            using (var client = new HttpClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7015/api/Doctor");
                var response = client.SendAsync(requestMessage).Result;
                var data = response.Content.ReadAsAsync<List<Doctor>>().Result;

                foreach (var doctor in data)
                {
                    var currentDoctor = new AllDoctorsViewModel
                    {
                        Id = doctor.UserId,
                        FullName = doctor.FirstName + " " + doctor.LastName,
                        Specialization = doctor.Specialization,
                        ContactNumber = doctor.ContactNumber,
                        Gender = doctor.Gender,
                        Image = doctor.DoctorPicture,
                        UserName = _unitOfWork.GenericRepository<User>().GetById(doctor.UserId).UserName,
                    };

                    var headDoctor = _unitOfWork.GenericRepository<HeadDoctor>().GetById(doctor.Id);

                    if(headDoctor != null)
                    {
                        currentDoctor.IsHeadDoctor = true;
                    }

                    if(doctor.InstitutionId != null)
                    {
                        currentDoctor.Institution = _unitOfWork.GenericRepository<Institution>().GetById(doctor.InstitutionId).Name;
                    }

                    doctors.Add(currentDoctor);
                }
            }
            return doctors;
        }

        public async Task ChangeDoctor(DoctorProfileViewModel model, string userId)
        {
            var doctor = _unitOfWork.GenericRepository<Doctor>().GetAll().FirstOrDefault(doctor => doctor.UserId == userId); 

            doctor.FirstName = model.FirstName;
            doctor.LastName = model.LastName;
            doctor.ContactNumber = model.ContactNumber;
            doctor.Age = model.Age;
            doctor.Specialization = model.Specialization;
            doctor.Gender = model.Gender;

            if (model.DoctorPicture != null)
            {
                string uniqueFileName = null;
                if (model.DoctorPicture != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    uniqueFileName = model.DoctorPicture.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        model.DoctorPicture.CopyTo(fileStream);
                    }
                }
                doctor.DoctorPicture = uniqueFileName;
            }

            _unitOfWork.GenericRepository<Doctor>().Update(doctor);

            await _unitOfWork.SaveAsync();
        }

        public Doctor GetByUserId(string userId)
        {
            return _unitOfWork.GenericRepository<Doctor>().GetAll().FirstOrDefault(d => d.UserId == userId);
        }

        public Doctor GetById(int? id)
        {
            return _unitOfWork.GenericRepository<Doctor>().GetById(id);
        }

        public DoctorProfileViewModel ViewProfile(string userId)
        {
            var doctor = _unitOfWork.GenericRepository<Doctor>().GetAll().FirstOrDefault(d => d.UserId == userId);

            var doctorInfo = new DoctorProfileViewModel
            {
                Id = doctor.UserId,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                ContactNumber = doctor.ContactNumber,
                Age = doctor.Age,
                Specialization = doctor.Specialization,
                Gender = doctor.Gender,
                PictureName = doctor.DoctorPicture,
            };

            if(doctor.Institution != null)
            {
                doctorInfo.Institution = _unitOfWork.GenericRepository<Institution>().GetById(doctor.InstitutionId).Name;
            }
            return doctorInfo;
        }
    }
}
