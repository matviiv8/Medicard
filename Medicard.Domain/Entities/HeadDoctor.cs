using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Domain.Entities
{
    public class HeadDoctor
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        public int? InstitutionId { get; set; }

        public Institution? Institution { get; set; }
    }
}
