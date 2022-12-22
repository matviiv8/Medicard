using FluentAssertions;
using Medicard.Domain.Astract;
using Medicard.Domain.Astract.Repositories;
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

namespace Medicard.Tests.WebAPI.Controllers
{
    public class PatientControllerTests
    {
        private readonly Mock<IGenericRepository<Patient>> _patientRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public PatientControllerTests()
        {
            _patientRepository = new Mock<IGenericRepository<Patient>>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Test]
        public void GetAllPatients_ListOfPatients()
        {
            //arrange
            var patients = FakeDataBogus.GetPatients(3);

            _patientRepository.Setup(x => x.GetAll(null, null, ""))
                        .Returns(patients);
            _unitOfWork.Setup(x => x.GenericRepository<Patient>()).Returns(_patientRepository.Object);

            var controller = new PatientController(_unitOfWork.Object);

            //act
            var actionResult = controller.Get();
            var result = actionResult as OkObjectResult;
            var actual = result.Value as IEnumerable<Patient>;

            //assert
            Assert.AreEqual(FakeDataBogus.GetPatients(3).Count(), actual.Count());

            actual.Count().Should().Be(FakeDataBogus.GetPatients(3).Count());
        }

        [Test]
        public void GetAllPatients_WhenCalled_ReturnsOkResult()
        {
            //arrange
            var patients = FakeDataBogus.GetPatients(3);

            _patientRepository.Setup(x => x.GetAll(null, null, ""))
                        .Returns(patients);
            _unitOfWork.Setup(x => x.GenericRepository<Patient>()).Returns(_patientRepository.Object);

            var controller = new PatientController(_unitOfWork.Object);

            //act
            var actionResult = controller.Get();
            //assert
            Assert.IsInstanceOf<OkObjectResult>(actionResult as OkObjectResult);
        }

        [Test]
        public void GetById_ReturnsNotFoundResult_PatientWithIdNotExists()
        {
            //arrange
            var patients = FakeDataBogus.GetPatients(3);
            var firstPatient = patients[0];

            _patientRepository.Setup(x => x.GetById(1))
                        .Returns(firstPatient);
            _unitOfWork.Setup(x => x.GenericRepository<Patient>()).Returns(_patientRepository.Object);

            var controller = new PatientController(_unitOfWork.Object);

            //act
            var notFoundResult = controller.GetById(100);

            //assert
            Assert.IsInstanceOf<NotFoundResult>(notFoundResult);
        }

        [Test]
        public void GetById_PatientObject_PatientWithSpecificeIdExists()
        {
            //arrange
            var patients = FakeDataBogus.GetPatients(3);
            var firstPatient = patients[0];

            _patientRepository.Setup(x => x.GetById(1))
                        .Returns(firstPatient);
            _unitOfWork.Setup(x => x.GenericRepository<Patient>()).Returns(_patientRepository.Object);

            var controller = new PatientController(_unitOfWork.Object);

            //act
            var actionResult = controller.GetById(1);
            var result = actionResult as OkObjectResult;

            //assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.AreEqual(firstPatient, result.Value);

            firstPatient.Should().Be(result.Value);
        }
        [Test]
        public void Delete_NotExistingPatientPassed_ReturnsNotFoundResponse()
        {
            //arrange
            var patients = FakeDataBogus.GetPatients(3);
            var notExistingPatient = FakeDataBogus.GetPatients(1).First();

            _patientRepository.Setup(x => x.Delete(notExistingPatient));
            _unitOfWork.Setup(x => x.GenericRepository<Patient>()).Returns(_patientRepository.Object);
            var controller = new PatientController(_unitOfWork.Object);

            //act
            var badResponse = controller.Delete(notExistingPatient.Id);

            //assert
            Assert.IsInstanceOf<NotFoundResult>(badResponse);

            badResponse.Should().BeOfType<NotFoundResult>();
        }
        
        [Test]
        public void Delete_ExistingPatientPassed_ReturnOkResult()
        {
            //arrange
            var patients = FakeDataBogus.GetPatients(3);
            int maxID = patients.Max(a => a.Id);
            var lastPatient = patients.Last();

            _patientRepository.Setup(x => x.GetById(lastPatient.Id))
                        .Returns(lastPatient);
            _patientRepository.Setup(x => x.Delete(lastPatient));
            _unitOfWork.Setup(x => x.GenericRepository<Patient>()).Returns(_patientRepository.Object);
            var controller = new PatientController(_unitOfWork.Object);

            //act
            var result = controller.Delete(lastPatient.Id);
            OkResult okResult = result as OkResult;

            //assert
            Assert.IsInstanceOf<OkResult>(result);

            result.Should().NotBeNull();
            okResult.Should().NotBeNull();
        }
    }
}
