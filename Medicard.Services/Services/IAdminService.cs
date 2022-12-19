using Medicard.Services.ViewModels.Admin;
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
        public void DeleteDoctor(string id);
    }
}
