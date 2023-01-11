using Medicard.Domain.Astract.Repositories;
using Medicard.Domain.Concrete;
using Medicard.Domain.Entities;
using Medicard.Services.Services;
using Medicard.Services.ViewModels.Doctor;
using Medicard.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Medicard.WebUI.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IInstitutionService _institutionService;
        private readonly UserManager<User> _userManager;

        public DoctorController(IDoctorService doctorService, UserManager<User> userManager, IPatientService patientService, IInstitutionService institutionService)
        {
            _doctorService = doctorService;
            _userManager = userManager;
            _patientService = patientService;
            _institutionService = institutionService;
        }

        [AllowAnonymous]
        public IActionResult AllDoctors(string institution, string specialization, string search, int page = 1)
        {
            ViewData["Search"] = search;

            var doctors = _doctorService.AllDoctors();

            if (!string.IsNullOrEmpty(search))
            {
                doctors = doctors.Where(doctor => doctor.FullName.ToLower().Contains(search.ToLower()));
            }

            if (!string.IsNullOrEmpty(specialization))
            {
                doctors = doctors.Where(doctor => doctor.Specialization == specialization);
            }

            if (!string.IsNullOrEmpty(institution))
            {
                doctors = doctors.Where(doctor => doctor.Institution == institution);
            }

            int pageSize = 4;
            var count = doctors.Count();
            var items = doctors.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ViewData["Specializations"] = doctors.Select(doctor => doctor.Specialization).Distinct();
            PageViewModel pagingInfo = new PageViewModel(count, page, pageSize);
            ShowAllDoctorsViewModel viewModel = new ShowAllDoctorsViewModel
            {
                PagingInfo = pagingInfo,
                AllDoctors = items,
                Specializations = doctors.Select(doctor => doctor.Specialization).Distinct(),
                Institutions = _institutionService.AllInstitutions().Select(institution => institution.Name),
            };

            return View(viewModel);
        }

        public IActionResult ViewProfile()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var patient = this._doctorService.ViewProfile(userId);

            return this.View(patient);
        }

        public async Task<IActionResult> ChangeProfile(string id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var doctor = this._doctorService.ViewProfile(userId);

            return this.View(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeProfile(DoctorProfileViewModel model)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this._doctorService.ChangeDoctor(model, userId);

            return this.RedirectToAction("ViewProfile", "Doctor");
        }

        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> AppointPersonalDoctor(string id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var currentPatient = this._patientService.GetByUserId(userId);

            var doctor = this._doctorService.GetByUserId(id);

            if (doctor.Specialization.ToLower() == "family doctor" && doctor != null)
            {
                await this._patientService.AppointPersonalDoctor(currentPatient, id);

            }

            return this.RedirectToAction("AllDoctors", "Doctor");
        }
    }
}
