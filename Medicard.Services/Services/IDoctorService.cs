using Medicard.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.Services
{
    public interface IDoctorService
    {
        IEnumerable<AllDoctorsViewModel> GetAllDoctors();
    }
}
