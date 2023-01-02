using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Domain.Entities
{
    public class WorkHour
    {
        public int Id { get; set; }

        public string? Hour { get; set; }

        public int ScheduleId { get; set; }

        public Schedule Sсhedule { get; set; }
    }
}
