using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Domain.Entities
{
    public class Patient : User
    {
        public string Address { get; set; }
        public string BirthDate { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
