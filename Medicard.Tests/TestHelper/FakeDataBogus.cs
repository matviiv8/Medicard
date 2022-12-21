using Bogus;
using Medicard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Tests.TestHelper
{
    public class FakeDataBogus
    {
        private static List<Patient> _patients;
        private static List<Doctor> _doctors;

        public static List<Patient> GetPatients(int number)
        {
            if (_patients == null)
            {
                _patients = new Faker<Patient>()
                               .RuleFor(patient => patient.Id, faker => faker.IndexFaker + 1)
                               .RuleFor(patient => patient.FirstName, faker => faker.Name.FirstName())
                               .RuleFor(patient => patient.LastName, faker => faker.Name.LastName())
                               .RuleFor(patient => patient.ContactNumber, faker => faker.Person.Phone)
                               .RuleFor(patient => patient.Age, faker => faker.Random.Number(0, 110))
                               .RuleFor(patient => patient.BirthDate, faker => faker.Person.DateOfBirth.ToString())
                               .RuleFor(patient => patient.Address, faker => faker.Address.FullAddress())
                               .Generate(number);
            }

            return _patients;
        }

        public static List<Doctor> GetDoctors(int number)
        {
            if (_doctors == null)
            {
                _doctors = new Faker<Doctor>()
                               .RuleFor(doctor => doctor.Id, faker => faker.IndexFaker + 1)
                               .RuleFor(doctor => doctor.FirstName, faker => faker.Name.FirstName())
                               .RuleFor(doctor => doctor.LastName, faker => faker.Name.LastName())
                               .RuleFor(doctor => doctor.ContactNumber, faker => faker.Person.Phone)
                               .RuleFor(doctor => doctor.Age, faker => faker.Random.Number(0, 110))
                               .RuleFor(doctor => doctor.UserId, faker => faker.Random.Number(0,1000).ToString())
                               .Generate(number);
            }

            return _doctors;
        }
    }
}
