using Medicard.Domain.Entities;
using Medicard.Services.ViewModels.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services.Interfaces
{
    public interface IDoctorService
    {
        public IEnumerable<AllDoctorsViewModel> AllDoctors();
        DoctorProfileViewModel ViewProfile(string userId);
        Task ChangeDoctor(DoctorProfileViewModel model, string userId);
        Doctor GetByUserId(string userId);
        Doctor GetById(int? id);
    }
}
