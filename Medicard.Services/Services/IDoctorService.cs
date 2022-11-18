using Medicard.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services
{
    public interface IDoctorService
    {
        AllDoctorsViewModel allDoctors();
        DoctorProfileViewModel ViewProfile(string userId);
        Task ChangeDoctor(DoctorProfileViewModel model, string userId);
    }
}
