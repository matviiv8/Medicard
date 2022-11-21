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
    public class DoctorImageConfiguration : IEntityTypeConfiguration<DoctorImage>
    {
        public void Configure(EntityTypeBuilder<DoctorImage> builder)
        {
            builder.ToTable("Doctor image");
            builder.HasKey(x => x.Id);
        }
    }
}
