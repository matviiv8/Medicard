using Medicard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Domain.Concrete.EntityConfiguration
{
    public class WorkHourConfiguration : IEntityTypeConfiguration<WorkHour>
    {
        public void Configure(EntityTypeBuilder<WorkHour> builder)
        {
            builder.ToTable("Work hour");
            builder.HasData(SeedWorkHourBase());
        }

        private List<WorkHour> SeedWorkHourBase()
        {
            var hoursData = WorkHourConstants.AllWorkingHours
            .Split(",")
            .ToList();

            var hours = new List<WorkHour>();

            for (int i = 0; i < hoursData.Count; i++)
            {
                 hours.Add(new WorkHour { Id = i + 1, Hour = hoursData[i], ScheduleId = 1 });
            }

            return hours;
        }

        public class WorkHourConstants
        {
            public const string AllWorkingHours = "08:00,08:30,09:00,09:30,10:00,10:30,11:00,11:30,13:00,13:30,14:00,14:30,15:00,15:30,16:00,16:30,17:00,17:30,18:00";
        }
    }
}
