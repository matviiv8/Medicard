using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.ViewModels.Patient
{
    public class AllPatientsViewModel
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string? Address { get; set; }

        public string ContactNumber { get; set; }

        public string BirthDate { get; set; }

        public string? PersonalDoctorFullName { get; set; }
    }
}
