using Medicard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medicard.Domain.Concrete.EntityConfiguration.WorkHourConfiguration;

namespace Medicard.Domain.Concrete.EntityConfiguration
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedule");

            builder.Property(x => x.Id).IsRequired();
            builder.HasIndex(a => a.Id).IsUnique();

            builder.HasKey(x => x.Id);
            builder.HasData(SeedSheduleBase());
        }

        private List<Schedule> SeedSheduleBase()
        {
            var hoursData = WorkHourConstants.AllWorkingHours
            .Split(",")
            .ToList();

            var schedules = new List<Schedule>()
            {
                new Schedule { Id = 1, Name = "Shift" },
            };

            return schedules;
        }
    }
}
