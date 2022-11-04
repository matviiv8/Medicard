using Medicard.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Domain.Entities
{
    public class Doctor : User
    {
        public string Specialization { get; set; }
        public int InstitutionId { get; set; }
        public Institution Institution { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
