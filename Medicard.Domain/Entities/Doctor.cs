using Medicard.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Domain.Entities
{
    public class Doctor
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? ContactNumber { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public User? User { get; set; }

        public string UserId { get; set; }

        public string? Specialization { get; set; }

        public int? InstitutionId { get; set; }

        public Institution? Institution { get; set; }

        public List<Patient>? Patients { get; set; }
    }
}
