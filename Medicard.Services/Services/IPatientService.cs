using Medicard.Domain.Entities;
using Medicard.Services.ViewModels.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services
{
    public interface IPatientService
    {
        public IEnumerable<AllPatientsViewModel> AllPatients();
        PatientProfileViewModel ViewProfile(string userId);
        Task ChangePatient(PatientProfileViewModel model, string userId);
        Task AppointPersonalDoctor(Patient patient, string doctorsUserId);
        Patient GetByUserId(string userId);
    }
}
