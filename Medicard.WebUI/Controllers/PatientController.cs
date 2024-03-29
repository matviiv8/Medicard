﻿using Medicard.Domain.Astract.Repositories;
using Medicard.Domain.Concrete;
using Medicard.Domain.Entities;
using Medicard.Services.Services.Interfaces;
using Medicard.Services.ViewModels.Patient;
using Medicard.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Patient")]
        public IActionResult ViewProfile()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var patient = this._patientService.ViewProfile(userId);

            return this.View(patient);
        }

        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> ChangeProfile(string id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var patient = this._patientService.ViewProfile(userId);

            return this.View(patient);
        }

        [Authorize(Roles = "Patient")]
        [HttpPost]
        public async Task<IActionResult> ChangeProfile(PatientProfileViewModel model)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this._patientService.ChangePatient(model, userId);

            return this.RedirectToAction("ViewProfile", "Patient");
        }

        [Authorize(Roles = "Doctor, Head doctor")]
        public IActionResult AllPatients(string search, int page = 1)
        {
            ViewData["CurrentFilter"] = search;

            var patients = _patientService.AllPatients();

            if (!string.IsNullOrEmpty(search))
            {
                patients = patients.Where(patient => patient.FullName.ToLower().Contains(search.ToLower()));
            }

            int pageSize = 10;
            var count = patients.Count();
            var items = patients.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pagingInfo = new PageViewModel(count, page, pageSize);
            ShowAllPatientsViewModel viewModel = new ShowAllPatientsViewModel
            {
                PagingInfo = pagingInfo,
                AllPatients = items,
            };

            return View(viewModel);
        }
    }
}
