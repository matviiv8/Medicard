using Medicard.Domain.Entities;
using Medicard.Services.ViewModels.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services
{
    public interface IDoctorService
    {
        public IEnumerable<AllDoctorsViewModel> AllDoctors();
        DoctorProfileViewModel ViewProfile(string userId);
        Task ChangeDoctor(DoctorProfileViewModel model, string userId);
        Doctor GetById(string userId);
    }
}
