﻿// <auto-generated />
using System;
using Medicard.Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Medicard.Domain.Migrations
{
    [DbContext(typeof(MedicardDbContext))]
    partial class MedicardDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Medicard.Domain.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DiagnosisId")
                        .HasColumnType("int");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TreatmentPlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointment", (string)null);
                });

            modelBuilder.Entity("Medicard.Domain.Entities.Diagnosis", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("FinalDiagnosis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InitialDiagnosis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Diagnosis", (string)null);
                });

            modelBuilder.Entity("Medicard.Domain.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoctorPicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int?>("InstitutionId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<string>("Specialization")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("InstitutionId");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("UserId");

                    b.ToTable("Doctor", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 0,
                            DoctorPicture = "menunknowndoctor.jpeg",
                            FirstName = "Petro",
                            Gender = 1,
                            LastName = "Grinkiv",
                            Specialization = "Therapist",
                            UserId = "b36dca99-e522-476c-8682-31963ed65a99"
                        },
                        new
                        {
                            Id = 2,
                            Age = 0,
                            DoctorPicture = "womenunknowndoctor.jpeg",
                            FirstName = "Maria",
                            Gender = 2,
                            LastName = "Koval",
                            Specialization = "Pediatrician",
                            UserId = "b13950c5-1f45-47c5-926e-b061de9b0155"
                        });
                });

            modelBuilder.Entity("Medicard.Domain.Entities.HeadDoctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int?>("InstitutionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId")
                        .IsUnique();

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("InstitutionId")
                        .IsUnique()
                        .HasFilter("[InstitutionId] IS NOT NULL");

                    b.ToTable("HeadDoctor", (string)null);
                });

            modelBuilder.Entity("Medicard.Domain.Entities.Institution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkScheduleWeekdayEnd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkScheduleWeekdayStart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkScheduleWeekendEnd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkScheduleWeekendStart")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Institution", (string)null);
                });

            modelBuilder.Entity("Medicard.Domain.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TargetId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TargetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("When")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Message", (string)null);
                });

            modelBuilder.Entity("Medicard.Domain.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("BirthDate")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Patient", (string)null);
                });

            modelBuilder.Entity("Medicard.Domain.Entities.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Schedule", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Shift"
                        });
                });

            modelBuilder.Entity("Medicard.Domain.Entities.TreatmentPlan", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Analyzes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Pharmacy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TreatmentPlan");
                });

            modelBuilder.Entity("Medicard.Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "4e9cc035-1202-400c-bb21-678db5caf2be",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6c92e189-a63d-41df-90e3-b72f3879b517",
                            Email = "matviivandrij13@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Andrij",
                            LastName = "Matviiv",
                            LockoutEnabled = false,
                            NormalizedEmail = "MATVIIVANDRIJ13@GMAIL.COM",
                            NormalizedUserName = "MATVIIVANDRIJ13@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEOf7W1ifebmXDOK+DSU5LqCsvoM3L2bpdSTBfWtxb+TvSM/0vkzONAXAGcxu5OorLw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "345f8b72-147d-4f87-a6de-adfa31cad0a2",
                            TwoFactorEnabled = false,
                            UserName = "matviivandrij13@gmail.com"
                        },
                        new
                        {
                            Id = "b36dca99-e522-476c-8682-31963ed65a99",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7d8bef37-c1c3-46e3-a8a3-4164fa4c54a1",
                            Email = "petrogrinkiv@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Petro",
                            LastName = "Grinkiv",
                            LockoutEnabled = false,
                            NormalizedEmail = "PETROGRINKOV@GMAIL.COM",
                            NormalizedUserName = "PETROGRINKOV@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEE8IcjruRQQQXpuvIEitu+F93y0cRXnKpLJKkGNrzVVoItOJfbRC669GhviPOt4GyQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "41cc4aa2-03fd-4b2d-8bb2-c4e6f73aeaa5",
                            TwoFactorEnabled = false,
                            UserName = "petrogrinkiv@gmail.com"
                        },
                        new
                        {
                            Id = "b13950c5-1f45-47c5-926e-b061de9b0155",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3a48a3f9-1579-48ab-921c-6a925b582527",
                            Email = "mariakoval@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Maria",
                            LastName = "Koval",
                            LockoutEnabled = false,
                            NormalizedEmail = "MARIAKOVAL@GMAIL.COM",
                            NormalizedUserName = "MARIAKOVAL@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAECRWpXwbPyBJz33+l4wsUUATK4pNgVVfRelU+CSesPJjlEbiaKDvE0G4k1PQSRNPsQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1581259c-dc32-47b5-a4ba-f7998fdb2104",
                            TwoFactorEnabled = false,
                            UserName = "mariakoval@gmail.com"
                        });
                });

            modelBuilder.Entity("Medicard.Domain.Entities.WorkHour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Hour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Work hour", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Hour = "08:00",
                            ScheduleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Hour = "08:30",
                            ScheduleId = 1
                        },
                        new
                        {
                            Id = 3,
                            Hour = "09:00",
                            ScheduleId = 1
                        },
                        new
                        {
                            Id = 4,
                            Hour = "09:30",
                            ScheduleId = 1
                        },
                        new
                        {
                            Id = 5,
                            Hour = "10:00",
                            ScheduleId = 1
                        },
                        new
                        {
                            Id = 6,
                            Hour = "10:30",
                            ScheduleId = 1
                        },
                        new
                        {
                            Id = 7,
                            Hour = "11:00",
                            ScheduleId = 1
                        },
                        new
                        {
                            Id = 8,
                            Hour = "11:30",
                            ScheduleId = 1
                        },
                        new
                        {
                            Id = 9,
                            Hour = "13:00",
                            ScheduleId = 1
                        },
                        new
                        {
                            Id = 10,
                            Hour = "13:30",
                            ScheduleId = 1
                        },
                        new
                        {
                            Id = 11,
                            Hour = "14:00",
                            ScheduleId = 1
                        },
                        new
                        {
                            Id = 12,
                            Hour = "14:30",
                            ScheduleId = 1
                        },
                        new
                        {
                            Id = 13,
                            Hour = "15:00",
                            ScheduleId = 1
                        },
                        new
                        {
                            Id = 14,
                            Hour = "15:30",
                            ScheduleId = 1
                        },
                        new
                        {
                            Id = 15,
                            Hour = "16:00",
                            ScheduleId = 1
                        },
                        new
                        {
                            Id = 16,
                            Hour = "16:30",
                            ScheduleId = 1
                        },
                        new
                        {
                            Id = 17,
                            Hour = "17:00",
                            ScheduleId = 1
                        },
                        new
                        {
                            Id = 18,
                            Hour = "17:30",
                            ScheduleId = 1
                        },
                        new
                        {
                            Id = 19,
                            Hour = "18:00",
                            ScheduleId = 1
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "9f610d49-6c30-4c5d-804a-ab2921364dcc",
                            ConcurrencyStamp = "b6f6aa69-844c-43b9-8b91-a55c88e06582",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "83a69c00-3a44-415a-b786-a3dc4ffcfead",
                            ConcurrencyStamp = "6b2af985-8d4e-4593-9c8c-52e980c79a42",
                            Name = "Doctor",
                            NormalizedName = "DOCTOR"
                        },
                        new
                        {
                            Id = "769ae43d-38b1-443a-bc40-98b9f849c743",
                            ConcurrencyStamp = "68739016-cce6-4bac-8d0f-649bd5ed27ed",
                            Name = "Patient",
                            NormalizedName = "PATIENT"
                        },
                        new
                        {
                            Id = "60d49f1d-8580-478d-8316-d1cba80cf169",
                            ConcurrencyStamp = "00fee099-307b-4604-b2f3-bc85ce8b0aaa",
                            Name = "Head doctor",
                            NormalizedName = "HEAD DOCTOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "4e9cc035-1202-400c-bb21-678db5caf2be",
                            RoleId = "9f610d49-6c30-4c5d-804a-ab2921364dcc"
                        },
                        new
                        {
                            UserId = "b36dca99-e522-476c-8682-31963ed65a99",
                            RoleId = "83a69c00-3a44-415a-b786-a3dc4ffcfead"
                        },
                        new
                        {
                            UserId = "b13950c5-1f45-47c5-926e-b061de9b0155",
                            RoleId = "83a69c00-3a44-415a-b786-a3dc4ffcfead"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Medicard.Domain.Entities.Appointment", b =>
                {
                    b.HasOne("Medicard.Domain.Entities.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("Medicard.Domain.Entities.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Medicard.Domain.Entities.Diagnosis", b =>
                {
                    b.HasOne("Medicard.Domain.Entities.Appointment", "Appointment")
                        .WithOne("Diagnosis")
                        .HasForeignKey("Medicard.Domain.Entities.Diagnosis", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("Medicard.Domain.Entities.Doctor", b =>
                {
                    b.HasOne("Medicard.Domain.Entities.Institution", "Institution")
                        .WithMany("Doctors")
                        .HasForeignKey("InstitutionId");

                    b.HasOne("Medicard.Domain.Entities.Schedule", "Schedule")
                        .WithMany("Doctors")
                        .HasForeignKey("ScheduleId");

                    b.HasOne("Medicard.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institution");

                    b.Navigation("Schedule");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Medicard.Domain.Entities.HeadDoctor", b =>
                {
                    b.HasOne("Medicard.Domain.Entities.Doctor", "Doctor")
                        .WithOne("HeadDoctor")
                        .HasForeignKey("Medicard.Domain.Entities.HeadDoctor", "DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Medicard.Domain.Entities.Institution", "Institution")
                        .WithOne("HeadDoctor")
                        .HasForeignKey("Medicard.Domain.Entities.HeadDoctor", "InstitutionId");

                    b.Navigation("Doctor");

                    b.Navigation("Institution");
                });

            modelBuilder.Entity("Medicard.Domain.Entities.Message", b =>
                {
                    b.HasOne("Medicard.Domain.Entities.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Medicard.Domain.Entities.Patient", b =>
                {
                    b.HasOne("Medicard.Domain.Entities.Doctor", "Doctor")
                        .WithMany("Patients")
                        .HasForeignKey("DoctorId");

                    b.HasOne("Medicard.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Medicard.Domain.Entities.TreatmentPlan", b =>
                {
                    b.HasOne("Medicard.Domain.Entities.Appointment", "Appointment")
                        .WithOne("TreatmentPlan")
                        .HasForeignKey("Medicard.Domain.Entities.TreatmentPlan", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("Medicard.Domain.Entities.WorkHour", b =>
                {
                    b.HasOne("Medicard.Domain.Entities.Schedule", "Sсhedule")
                        .WithMany("WorkHours")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sсhedule");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Medicard.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Medicard.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Medicard.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Medicard.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Medicard.Domain.Entities.Appointment", b =>
                {
                    b.Navigation("Diagnosis");

                    b.Navigation("TreatmentPlan");
                });

            modelBuilder.Entity("Medicard.Domain.Entities.Doctor", b =>
                {
                    b.Navigation("HeadDoctor")
                        .IsRequired();

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("Medicard.Domain.Entities.Institution", b =>
                {
                    b.Navigation("Doctors");

                    b.Navigation("HeadDoctor")
                        .IsRequired();
                });

            modelBuilder.Entity("Medicard.Domain.Entities.Patient", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Medicard.Domain.Entities.Schedule", b =>
                {
                    b.Navigation("Doctors");

                    b.Navigation("WorkHours");
                });

            modelBuilder.Entity("Medicard.Domain.Entities.User", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
