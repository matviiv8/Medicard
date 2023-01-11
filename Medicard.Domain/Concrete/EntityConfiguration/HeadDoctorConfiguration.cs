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
    public class HeadDoctorConfiguration : IEntityTypeConfiguration<HeadDoctor>
    {
        public void Configure(EntityTypeBuilder<HeadDoctor> builder)
        {
            builder.ToTable("HeadDoctor");

            builder.Property(x => x.Id).IsRequired();

            builder.HasIndex(a => a.Id).IsUnique();
            builder.Property(x => x.DoctorId).IsRequired();
            builder.HasKey(x => x.Id);
        }
    }
}
