using Medicard.Domain.Concrete;
using Medicard.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly MedicardDbContext _context;

        public DoctorService(MedicardDbContext context)
        {
            this._context = context;
        }

        public AllDoctorsViewModel allDoctors()
        {
            AllDoctorsViewModel doctors = new AllDoctorsViewModel()
            {
                Doctors = _context.Doctors.ToList(),
            };

            return doctors;
        }

        public async Task ChangeDoctor(DoctorProfileViewModel model, string userId)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.UserId == userId);

            doctor.FirstName = model.FirstName;
            doctor.LastName = model.LastName;
            doctor.ContactNumber = model.ContactNumber;
            doctor.Age = model.Age;
            doctor.Specialization = model.ContactNumber;
            doctor.Gender = model.Gender;

            _context.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public DoctorProfileViewModel ViewProfile(string userId)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.UserId == userId);

            var doctorInfo = new DoctorProfileViewModel
            {
                Id = doctor.UserId,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                ContactNumber = doctor.ContactNumber,
                Age = doctor.Age,
                Specialization = doctor.ContactNumber,
                Gender = doctor.Gender,
            };

            return doctorInfo;
        }
    }
}
