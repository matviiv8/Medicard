using Medicard.Domain.Astract.Repositories;
using Medicard.Domain.Concrete;
using Medicard.Domain.Entities;
using Medicard.Services.Services;
using Medicard.Services.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Medicard.WebUI.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly UserManager<User> _userManager;

        public PatientController(IPatientService patientService, UserManager<User> userManager)
        {
            _patientService = patientService;
            _userManager = userManager;
        }

        public IActionResult ViewProfile()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var patient = this._patientService.ViewProfile(userId);

            return this.View(patient);
        }

        public async Task<IActionResult> ChangeProfile(string id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var patient = this._patientService.ViewProfile(userId);

            return this.View(patient);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeProfile(PatientProfileViewModel model)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this._patientService.ChangePatient(model, userId);

            return this.RedirectToAction("ViewProfile", "Patient");
        }
    }
}
