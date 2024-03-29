﻿using Medicard.Domain.Concrete.EntityConfiguration;
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
        public MedicardDbContext(DbContextOptions<MedicardDbContext> options) : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<HeadDoctor> HeadDoctors { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Diagnosis> Diagnoses { get; set; }

        public DbSet<Institution> Institutions { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<WorkHour> WorkHours { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DoctorConfiguration());
            builder.ApplyConfiguration(new AppointmentConfiguration());
            builder.ApplyConfiguration(new PatientConfiguration());
            builder.ApplyConfiguration(new InstitutionConfiguration());
            builder.ApplyConfiguration(new DiagnosisConfiguration());
            builder.ApplyConfiguration(new MessageConfiguration());
            builder.ApplyConfiguration(new ScheduleConfiguration());
            builder.ApplyConfiguration(new WorkHourConfiguration());
            builder.ApplyConfiguration(new HeadDoctorConfiguration());

            builder.Entity<Doctor>()
                .HasMany(doctor => doctor.Patients)
                .WithOne(patient => patient.Doctor)
                .HasForeignKey(patient => patient.DoctorId);

            builder.Entity<Doctor>()
                .HasOne(doctor => doctor.HeadDoctor)
                .WithOne(headDoctor => headDoctor.Doctor)
                .HasForeignKey<HeadDoctor>(headDoctor => headDoctor.DoctorId);

            builder.Entity<Institution>()
                .HasOne(institution => institution.HeadDoctor)
                .WithOne(headDoctor => headDoctor.Institution)
                .HasForeignKey<HeadDoctor>(headDoctor => headDoctor.InstitutionId);

            builder.Entity<Doctor>()
                .HasOne(doctor => doctor.Schedule)
                .WithMany(schedule => schedule.Doctors)
                .HasForeignKey(doctor => doctor.ScheduleId);

            builder.Entity<WorkHour>()
                .HasOne(workHour => workHour.Sсhedule)
                .WithMany(schedule => schedule.WorkHours)
                .HasForeignKey(workHour => workHour.ScheduleId);

            builder.Entity<Patient>()
                .HasMany(patient => patient.Appointments)
                .WithOne(appointment => appointment.Patient)
                .HasForeignKey(appointment => appointment.PatientId);

            builder.Entity<Appointment>()
                .HasOne(appointment => appointment.Diagnosis)
                .WithOne(diagnosis => diagnosis.Appointment)
                .HasForeignKey<Diagnosis>(diagnosis => diagnosis.Id);

            builder.Entity<Appointment>()
                .HasOne(appointment => appointment.TreatmentPlan)
                .WithOne(treatmentPlan => treatmentPlan.Appointment)
                .HasForeignKey<TreatmentPlan>(treatmentPlan => treatmentPlan.Id);

            builder.Entity<Message>()
                .HasOne<User>(message => message.User)
                .WithMany(user => user.Messages)
                .HasForeignKey(message => message.UserId);

            var hasher = new PasswordHasher<IdentityUser>();

            var admin = new User
            {
                FirstName = "Andrij",
                LastName = "Matviiv",
                Email = "matviivandrij13@gmail.com",
                UserName = "matviivandrij13@gmail.com",
                NormalizedEmail = "MATVIIVANDRIJ13@GMAIL.COM",
                NormalizedUserName = "MATVIIVANDRIJ13@GMAIL.COM",
            };
            var firstDoctor = new User
            {
                FirstName = "Petro",
                LastName = "Grinkiv",
                Email = "petrogrinkiv@gmail.com",
                UserName = "petrogrinkiv@gmail.com",
                NormalizedEmail = "PETROGRINKOV@GMAIL.COM",
                NormalizedUserName = "PETROGRINKOV@GMAIL.COM",
            };
            var secondDoctor = new User
            {
                FirstName = "Maria",
                LastName = "Koval",
                Email = "mariakoval@gmail.com",
                UserName = "mariakoval@gmail.com",
                NormalizedEmail = "MARIAKOVAL@GMAIL.COM",
                NormalizedUserName = "MARIAKOVAL@GMAIL.COM",
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
                new IdentityRole { Name = "Patient", NormalizedName = "PATIENT" },
                new IdentityRole {Name = "Head doctor", NormalizedName = "HEAD DOCTOR"},
            };
            builder.Entity<IdentityRole>().HasData(roles);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = admin.Id,
                    RoleId =
                    roles.First(q => q.Name == "Admin").Id,
                },
                new IdentityUserRole<string>
                {
                    UserId = firstDoctor.Id,
                    RoleId =
                    roles.First(q => q.Name == "Doctor").Id,
                },
                new IdentityUserRole<string>
                {
                    UserId = secondDoctor.Id,
                    RoleId =
                    roles.First(q => q.Name == "Doctor").Id,
                });
            builder.Entity<Doctor>()
                .HasData(
                new Doctor
                {
                    Id = 1,
                    UserId = firstDoctor.Id,
                    FirstName = firstDoctor.FirstName,
                    LastName = firstDoctor.LastName,
                    Specialization = "Therapist",
                    Gender = Entities.Enums.Gender.Male,
                    DoctorPicture = "menunknowndoctor.jpeg",
                },
                new Doctor
                {
                    Id = 2,
                    UserId = secondDoctor.Id,
                    FirstName = secondDoctor.FirstName,
                    LastName = secondDoctor.LastName,
                    Specialization = "Pediatrician",
                    Gender = Entities.Enums.Gender.Female,
                    DoctorPicture = "womenunknowndoctor.jpeg",
                });
            base.OnModelCreating(builder);
        }
    }
}
