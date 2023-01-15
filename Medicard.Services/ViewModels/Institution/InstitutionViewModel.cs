using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Services.ViewModels.Institution
{
    public class InstitutionViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string? WorkScheduleWeekdayStart { get; set; }

        public string? WorkScheduleWeekdayEnd { get; set; }

        public string? WorkScheduleWeekendStart { get; set; }

        public string? WorkScheduleWeekendEnd { get; set; }

        public string? ContactNumber { get; set; }

        public int? HeadDoctorId { get; set; }
    }
}
