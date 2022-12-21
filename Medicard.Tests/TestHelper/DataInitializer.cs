using Medicard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Tests.TestHelper
{
    public class DataInitializer
    {
        public static List<Doctor> GetAllDoctors()
        {
            var users = GetAllUsers();

            var doctors = new List<Doctor> {
                new Doctor
                {
                    Id = 1,
                    UserId = users[0].Id,
                    FirstName = users[0].FirstName,
                    LastName = users[0].LastName,
                    Gender = Medicard.Domain.Entities.Enums.Gender.Male,
                    DoctorPicture = "menunknowndoctor.jpeg",
                },
                new Doctor
                {
                    Id = 2,
                    UserId = users[1].Id,
                    FirstName = users[1].FirstName,
                    LastName = users[1].LastName,
                    Gender = Medicard.Domain.Entities.Enums.Gender.Female,
                    DoctorPicture = "womenunknowndoctor.jpeg",
                }
            };
            return doctors;
        }
        public static List<User> GetAllUsers()
        {
            var users = new List<User> {
                new User
                {
                    FirstName = "Petro",
                    LastName = "Grinkiv",
                    Email = "petrogrinkiv@gmail.com",
                    UserName = "petrogrinkiv@gmail.com",
                    NormalizedEmail = "PETROGRINKOV@GMAIL.COM",
                    NormalizedUserName = "PETROGRINKOV@GMAIL.COM",
                },
                new User
                {
                    FirstName = "Maria",
                    LastName = "Koval",
                    Email = "mariakoval@gmail.com",
                    UserName = "mariakoval@gmail.com",
                    NormalizedEmail = "MARIAKOVAL@GMAIL.COM",
                    NormalizedUserName = "MARIAKOVAL@GMAIL.COM",
                }
            };

            return users;
        }
    }
}
