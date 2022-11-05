using Medicard.Domain.Concrete.EntityConfiguration;
using Medicard.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Domain.Concrete
{
    public class MedicardDbContext : IdentityDbContext<User>
    {   
        public MedicardDbContext() { }
        public MedicardDbContext(DbContextOptions<MedicardDbContext> options) : base(options) { }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new DoctorConfiguration());
            builder.ApplyConfiguration(new AppointmentConfiguration());
            builder.ApplyConfiguration(new PatientConfiguration());
            builder.ApplyConfiguration(new InstitutionConfiguration());
            builder.ApplyConfiguration(new DiagnosisConfiguration());

            builder.Entity<Doctor>()
                .HasMany(p => p.Patients)
                .WithOne(t => t.Doctor)
                .HasForeignKey(p => p.DoctorId);

            builder.Entity<Institution>()
                .HasMany(p => p.Doctors)
                .WithOne(t => t.Institution)
                .HasForeignKey(p => p.InstitutionId);

            builder.Entity<Patient>()
                .HasMany(p => p.Appointments)
                .WithOne(t => t.Patient)
                .HasForeignKey(p => p.PatientId);

            builder.Entity<Appointment>()
                .HasOne(p => p.Diagnosis)
                .WithOne(t => t.Appointment)
                .HasForeignKey<Diagnosis>(p => p.Id);

            builder.Entity<Appointment>()
                .HasOne(p => p.TreatmentPlan)
                .WithOne(t => t.Appointment)
                .HasForeignKey<TreatmentPlan>(p => p.Id);

        }
    }
}
