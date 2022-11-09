using Medicard.Domain.Astract.Repositories;
using Medicard.Domain.Concrete;
using Medicard.Domain.Entities;
using Medicard.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medicard.WebUI.Controllers
{
    public class DoctorController : Controller
    {
        private IGenericRepository<Doctor> repository;
        public DoctorController(IGenericRepository<Doctor> repository)
        {
            this.repository = repository;
        }
        public IActionResult AllDoctors(string search)
        {
            ViewData["CurrentFilter"] = search;

            AllDoctorsViewModel model = new AllDoctorsViewModel()
            {
                Doctors = repository.GetAll()
            };

            if (!string.IsNullOrEmpty(search))
            {
                model.Doctors = model.Doctors.Where(doctor => doctor.LastName.ToLower().Contains(search)
                                       || doctor.FirstName.ToLower().Contains(search));
            }
            return View(model);
        }
    }
}
