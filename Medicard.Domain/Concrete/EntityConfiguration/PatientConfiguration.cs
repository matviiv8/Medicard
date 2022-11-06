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
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patient");

            builder.Property(x => x.Id).IsRequired();
            builder.HasIndex(a => a.Id).IsUnique();

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Address).HasMaxLength(250);
            builder.Property(x => x.BirthDate).HasMaxLength(100);
        }
    }
}
