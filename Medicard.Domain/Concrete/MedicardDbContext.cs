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
            var firstDoctor = new User
            {
                FirstName = "Petro",
                LastName = "Grinkiv",
                Email = "petrogrinkiv@gmail.com",
                UserName = "petrogrinkiv@gmail.com"
            };
            var secondDoctor = new User
            {
                FirstName = "Maria",
                LastName = "Koval",
                Email = "mariakoval@gmail.com",
                UserName = "mariakoval@gmail.com"
            };

            var identityUser = new IdentityUser(admin.Id.ToString());
            var identityFirstDoctor = new IdentityUser(firstDoctor.Id.ToString());
            var identitySecondDoctor = new IdentityUser(secondDoctor.Id.ToString());

            firstDoctor.PasswordHash = hasher.HashPassword(identityFirstDoctor, "PetroG12@");
            secondDoctor.PasswordHash = hasher.HashPassword(identitySecondDoctor, "MariaK12@");
            admin.PasswordHash = hasher.HashPassword(identityUser, "Andrew13mtv@");

            builder.Entity<User>()
                .HasData(admin,firstDoctor,secondDoctor);

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
                    UserId = firstDoctor.Id,
                    RoleId =
                    roles.First(q => q.Name == "Doctor").Id
                });
            builder.Entity<Doctor>()
                .HasData(new Doctor
                {
                    Id = 1,
                    UserId = firstDoctor.Id,
                    FirstName = firstDoctor.FirstName,
                    LastName = firstDoctor.LastName,
                    Specialization = "Therapist"
                },
                new Doctor
                {
                    Id=2,
                    UserId= secondDoctor.Id,
                    FirstName = secondDoctor.FirstName,
                    LastName = secondDoctor.LastName,
                    Specialization = "Pediatrician"
                });
            base.OnModelCreating(builder);
        }
    }
}
