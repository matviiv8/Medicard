using Medicard.Domain.Concrete;
using Medicard.WebUI.Models;
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
        public IEnumerable<AllDoctorsViewModel> GetAllDoctors()
        {
           return _context.Doctors.
        }
    }
}
