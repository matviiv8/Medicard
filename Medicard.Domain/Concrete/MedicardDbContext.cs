using Medicard.Domain.Concrete.EntityConfiguration;
using Medicard.Domain.Entities;
using Microsoft.AspNetCore.Identity;
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
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DoctorConfiguration());
            builder.ApplyConfiguration(new AppointmentConfiguration());
            builder.ApplyConfiguration(new PatientConfiguration());
            builder.ApplyConfiguration(new InstitutionConfiguration());
            builder.ApplyConfiguration(new DiagnosisConfiguration());

            builder.Entity<Doctor>()
                .HasMany(p => p.Patients)
                .WithOne(t => t.Doctor)
                .HasForeignKey(p => p.DoctorId);

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

            var hasher = new PasswordHasher<IdentityUser>();

            var admin = new User
            {
                FirstName = "Andrij",
                LastName = "Matviiv",
                Email = "matviivandrij13@gmail.com",
                UserName = "matviivandrij13@gmail.com"
            };
            var doctor = new User
            {
                FirstName = "Petro",
                LastName = "Grinkiv",
                Email = "petrogrinkiv@gmail.com",
                UserName = "petrogrinkiv@gmail.com"
            };

            var identityUser = new IdentityUser(admin.Id.ToString());
            var identityDoctor = new IdentityUser(doctor.Id.ToString());

            doctor.PasswordHash = hasher.HashPassword(identityDoctor, "PetroG12@");
            admin.PasswordHash = hasher.HashPassword(identityUser, "Andrew13mtv@");

            builder.Entity<User>()
                .HasData(admin,doctor);

            var roles = new List<IdentityRole>()
            {
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "Doctor", NormalizedName = "DOCTOR" },
                new IdentityRole { Name = "Patient", NormalizedName = "PATIENT" }
            };
            builder.Entity<IdentityRole>().HasData(roles);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = admin.Id,
                    RoleId =
                    roles.First(q => q.Name == "Admin").Id
                },
                new IdentityUserRole<string>
                {
                    UserId = doctor.Id,
                    RoleId =
                    roles.First(q => q.Name == "Doctor").Id
                });
            builder.Entity<Doctor>()
                .HasData(new Doctor
                {
                    Id = 1,
                    UserId = doctor.Id
                });
            base.OnModelCreating(builder);
        }
    }
}
