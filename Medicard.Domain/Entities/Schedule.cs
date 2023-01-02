using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Domain.Entities
{
    public class Schedule
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public List<WorkHour> WorkHours { get; set; } = new List<WorkHour>();

        public List<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
