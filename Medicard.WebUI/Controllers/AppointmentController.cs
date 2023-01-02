﻿using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Medicard.Domain.Entities;
using Medicard.Services.Services;
using Medicard.Services.ViewModels.Appointment;
using Medicard.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Medicard.WebUI.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly UserManager<User> _userManager;

        public AppointmentController(IAppointmentService appointmentService, IDoctorService doctorService, IPatientService patientService, UserManager<User> userManager)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
            _patientService = patientService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Appoint(string id)
        {
            var model = this._appointmentService.FillAppointViewModel(id);
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Appoint(AppointmentViewModel model)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.Users.Where(user => user.Id == userId).FirstOrDefault();
            var doctor = _doctorService.GetById(model.DoctorId);
            var patient = _patientService.GetByUserId(userId);
            var appointment = _appointmentService.GetByDoctorId(doctor.Id);
            
            await _appointmentService.CreateAppointment(patient, doctor, model);

            return this.RedirectToAction("AllAppointments", "Appointment");
        }

        [HttpGet]
        public async Task<IActionResult> AllAppointments()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var allAppointments = _appointmentService.GetAllAppointments()
                .OrderBy(appointment => DateTime.Parse(appointment.Date)).ThenBy(appointment => DateTime.Parse(appointment.Time));

            if (this.User.IsInRole("Patient"))
            {
                return View(new ShowAllUserAppointmentsViewModel
                {
                    AllAppointments = allAppointments.Where(appointment => appointment.PatientId == _patientService.GetByUserId(userId).Id),
                });
            }
            else if(this.User.IsInRole("Doctor"))
            {
                return View(new ShowAllUserAppointmentsViewModel
                {
                    AllAppointments = allAppointments.Where(appointment => appointment.DoctorId == _doctorService.GetByUserId(userId).Id)
                });
            }
            else
            {
                return View(new ShowAllUserAppointmentsViewModel
                {
                    AllAppointments = allAppointments,
                });
            }
        }

        public IActionResult DeleteAppointment(int id)
        {
            this._appointmentService.DeleteAppointment(id);

            return this.RedirectToAction("AllAppointments", "Appointment");
        }
    }
}
