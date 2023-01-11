using Medicard.Services.ViewModels.Admin;
using Medicard.Services.ViewModels.Institution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services
{
    public interface IAdminService
    {
        public Task CreateDoctor(CreateDoctorViewModel doctor);

        public Task CreateInstitution(InstitutionViewModel institution);

        public void DeleteDoctor(string id);

        public void DeleteInstitution(int institutionId);
        Task ChangeInstitution(InstitutionViewModel model, int id);
    }
}
z