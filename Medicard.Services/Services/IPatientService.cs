using Medicard.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services
{
    public interface IPatientService
    {
        PatientProfileViewModel ViewProfile(string userId);
        Task ChangePatient(PatientProfileViewModel model, string userId);
    }
}
