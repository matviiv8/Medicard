using Medicard.Domain.Astract.Repositories;
using Medicard.Domain.Concrete;
using Medicard.Domain.Entities;
using Medicard.Services.Services;
using Medicard.Services.ViewModels.Doctor;
using Medicard.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Medicard.WebUI.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly UserManager<User> _userManager;

        public DoctorController(IDoctorService doctorService, UserManager<User> userManager)
        {
            _doctorService = doctorService;
            _userManager = userManager;
        }

        public IActionResult AllDoctors(string search, int page = 1)
        {
            ViewData["CurrentFilter"] = search;

            var doctors = _doctorService.AllDoctors();

            foreach (var doctor in doctors)
            {
                if (!string.IsNullOrEmpty(search))
                {
                    doctors = (List<AllDoctorsViewModel>)doctors.Where(doctor => doctor.FullName.ToLower().Contains(search.ToLower()));
                }
            }

            int pageSize = 4;
            var count = doctors.Count();
            var items = doctors.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pagingInfo = new PageViewModel(count, page, pageSize);
            ShowAllDoctorsViewModel viewModel = new ShowAllDoctorsViewModel
            {
                PagingInfo = pagingInfo,
                AllDoctors = items,
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
    }
}
