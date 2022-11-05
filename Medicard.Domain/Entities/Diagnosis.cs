using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Domain.Entities
{
    public class Diagnosis
    {
        public int Id { get; set; }
        public Appointment Appointment { get; set; }
        public string InitialDiagnosis { get; set; }
        public string FinalDiagnosis { get; set; }
    }
}
