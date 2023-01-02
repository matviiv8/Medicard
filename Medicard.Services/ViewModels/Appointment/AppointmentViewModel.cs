using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.ViewModels.Appointment
{
    public class AppointmentViewModel
    {
        public int Id { get; set; } 

        public string? DoctorFullName { get; set; }

        public string? PatientFullName { get; set; }

        public string? DoctorConctactNumber { get; set; }

        public string? InstitutionName { get; set; }

        public string? InstitutionAddress { get; set; }

        public string Date { get; set; } = null!;

        public string Time { get; set; } = null!;

        public int? PatientId { get; set; }

        public int? DoctorId { get; set; }

        public string? ProfileImage { get; set; }

        public string? Specialization { get; set; }

        public IEnumerable<string> WorkHours { get; set; } = new List<string>();
    }
}
