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
	class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
	{
		public void Configure(EntityTypeBuilder<Doctor> builder)
		{
			builder.ToTable("Doctor");

			builder.Property(x => x.Id).IsRequired();
			builder.HasIndex(a => a.Id).IsUnique();
			builder.Property(x => x.UserId).IsRequired();
			builder.Property(x => x.User).IsRequired();

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Institution).HasMaxLength(250);
			builder.Property(x => x.Specialization).HasMaxLength(100);

		}
	}
}