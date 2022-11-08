using Medicard.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string? ContactNumber { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public User? User { get; set; }
        public string UserId { get; set; }
        public string? Address { get; set; }
        public string? BirthDate { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public List<Appointment>? Appointments { get; set; }
    }
}
