using Medicard.Domain.Astract;
using Medicard.Domain.Concrete;
using Medicard.Domain.Entities;
using Medicard.Services.ViewModels.Doctor;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IEnumerable<AllDoctorsViewModel> allDoctors()
        {
            var users = _unitOfWork.GenericRepository<Doctor>().GetAll();
            var doctors = new List<AllDoctorsViewModel>();
            foreach(var user in users)
            {
                doctors.Add(new AllDoctorsViewModel
                {
                    Id = user.UserId,
                    FullName = user.FirstName + " " + user.LastName,
                    Specialization = user.Specialization,
                    ContactNumber = user.ContactNumber,
                    Gender = user.Gender,
                    Image = user.DoctorPicture,
                }); 
            }

            return doctors;
        }

        public async Task ChangeDoctor(DoctorProfileViewModel model, string userId)
        {
            var doctor = _unitOfWork.GenericRepository<Doctor>().GetAll().FirstOrDefault(d => d.UserId == userId);

            doctor.FirstName = model.FirstName;
            doctor.LastName = model.LastName;
            doctor.ContactNumber = model.ContactNumber;
            doctor.Age = model.Age;
            doctor.Specialization = model.Specialization;
            doctor.Gender = model.Gender;

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

            _unitOfWork.GenericRepository<Doctor>().Update(doctor);

            await _unitOfWork.SaveAsync();
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

            return doctorInfo;
        }
    }
}
