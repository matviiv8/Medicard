using Medicard.Domain.Astract.Repositories;
using Medicard.Domain.Concrete;
using Medicard.Domain.Entities;
using Medicard.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Medicard.WebUI.Controllers
{
    public class PatientController : Controller
    {
        private readonly IGenericRepository<Patient> _repository;
        private readonly UserManager<User> _userManager;

        public PatientController(IGenericRepository<Patient> repository, UserManager<User> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public IActionResult ViewProfile()
        {
            var patient = _repository.GetAll().FirstOrDefault(u => u.UserId == this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var patientInfo = new PatientProfileViewModel
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                BirthDate = patient.BirthDate,
                Address = patient.Address,
                Age = patient.Age,
                ContactNumber = patient.ContactNumber,
                Gender = patient.Gender,
                MaritalStatus = patient.MaritalStatus,
            };

            return View(patientInfo);
        }
    }
}
