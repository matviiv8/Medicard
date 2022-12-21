using Medicard.Domain.Astract;
using Medicard.Domain.Astract.Repositories;
using Medicard.Domain.Concrete;
using Medicard.Domain.Entities;
using Medicard.Tests.TestHelper;
using Medicard.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Medicard.Tests.WebAPI.Controllers
{
    public class DoctorControllerTests
    {
        private readonly Mock<IGenericRepository<Doctor>> _doctorRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public DoctorControllerTests()
        {
            _doctorRepository = new Mock<IGenericRepository<Doctor>>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        private static List<Doctor> SetUpDoctors()
        {
            var doctorId = new int();
            var doctors = DataInitializer.GetAllDoctors();
            foreach (var doctor in doctors)
            {
                doctor.Id = ++doctorId;
            }

            return doctors;
        }

        [Test]
        public void GetAllDoctors_ListOfDoctors()
        {
            //arrange
            var doctors = SetUpDoctors();

            _doctorRepository.Setup(x => x.GetAll(null, null, ""))
                        .Returns(doctors);
            _unitOfWork.Setup(x => x.GenericRepository<Doctor>()).Returns(_doctorRepository.Object);

            var controller = new DoctorController(_unitOfWork.Object);

            //act
            var actionResult = controller.Get();
            var result = actionResult as OkObjectResult;
            var actual = result.Value as IEnumerable<Doctor>;

            //assert
            Assert.AreEqual(SetUpDoctors().Count(), actual.Count());

            actual.Count().Should().Be(SetUpDoctors().Count());
        }

        [Test]
        public void GetAllDoctors_WhenCalled_ReturnsOkResult()
        {
            //arrange
            var doctors = SetUpDoctors();

            _doctorRepository.Setup(x => x.GetAll(null, null, ""))
                        .Returns(doctors);
            _unitOfWork.Setup(x => x.GenericRepository<Doctor>()).Returns(_doctorRepository.Object);

            var controller = new DoctorController(_unitOfWork.Object);

            //act
            var actionResult = controller.Get();
            //assert
            Assert.IsInstanceOf<OkObjectResult>(actionResult as OkObjectResult);
        }

        [Test]
        public void GetById_ReturnsNotFoundResult_DoctorWithIdNotExists()
        {
            //arrange
            var doctors = SetUpDoctors();
            var firstDoctor = doctors[0];

            _doctorRepository.Setup(x => x.GetById(1))
                        .Returns(firstDoctor);
            _unitOfWork.Setup(x => x.GenericRepository<Doctor>()).Returns(_doctorRepository.Object);

            var controller = new DoctorController(_unitOfWork.Object);

            //act
            var notFoundResult = controller.GetById(100);

            //assert
            Assert.IsInstanceOf<NotFoundResult>(notFoundResult);
        }

        [Test]
        public void GetById_DoctorObject_DoctorWithSpecificeIdExists()
        {
            //arrange
            var doctors = SetUpDoctors();
            var firstDoctor = doctors[0];

            _doctorRepository.Setup(x => x.GetById(1))
                        .Returns(firstDoctor);
            _unitOfWork.Setup(x => x.GenericRepository<Doctor>()).Returns(_doctorRepository.Object);

            var controller = new DoctorController(_unitOfWork.Object);

            //act
            var actionResult = controller.GetById(1);
            var result = actionResult as OkObjectResult;

            //assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.AreEqual(firstDoctor, result.Value);

            firstDoctor.Should().Be(result.Value);
        }

        [Test]
        public void Delete_NotExistingDoctorPassed_ReturnsNotFoundResponse()
        {
            //arrange
            var doctors = SetUpDoctors();
            var notExistingDoctor = new Doctor
            {
                Id = 100,
                FirstName = "Karpen",
                LastName = "Karpenko",
                UserId = "DKfwrfekfkew",
                Gender = Domain.Entities.Enums.Gender.Male,
            };

            _doctorRepository.Setup(x => x.Delete(notExistingDoctor));
            _unitOfWork.Setup(x => x.GenericRepository<Doctor>()).Returns(_doctorRepository.Object);
            var controller = new DoctorController(_unitOfWork.Object);

            //act
            var badResponse = controller.Delete(notExistingDoctor.Id);

            //assert
            Assert.IsInstanceOf<NotFoundResult>(badResponse);

            badResponse.Should().BeOfType<NotFoundResult>();
        }

        [Test]
        public void Delete_ExistingDoctorPassed_ReturnOkResult()
        {
            //arrange
            var doctors = SetUpDoctors();
            int maxID = doctors.Max(a => a.Id);
            var lastDoctor = doctors.Last();

            _doctorRepository.Setup(x => x.GetById(lastDoctor.Id))
                        .Returns(lastDoctor);
            _doctorRepository.Setup(x => x.Delete(lastDoctor));
            _unitOfWork.Setup(x => x.GenericRepository<Doctor>()).Returns(_doctorRepository.Object);
            var controller = new DoctorController(_unitOfWork.Object);

            //act
            var result = controller.Delete(lastDoctor.Id);
            OkResult okResult = result as OkResult;

            //assert
            Assert.IsInstanceOf<OkResult>(result);

            result.Should().NotBeNull();
            okResult.Should().NotBeNull();
        }
    }
}
