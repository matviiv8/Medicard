using Medicard.Domain.Astract.Repositories;
using Medicard.Domain.Concrete;
using Medicard.Domain.Entities;
using Medicard.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medicard.WebUI.Controllers
{
    public class DoctorController : Controller
    {
        private IGenericRepository<Doctor> _repository;

        public DoctorController(IGenericRepository<Doctor> repository)
        {
            _repository = repository;
        }

        public IActionResult AllDoctors(string search)
        {
            ViewData["CurrentFilter"] = search;

            AllDoctorsViewModel model = new AllDoctorsViewModel()
            {
                Doctors = _repository.GetAll(),
            };

            if (!string.IsNullOrEmpty(search))
            {
                model.Doctors = model.Doctors.Where(doctor => doctor.LastName.ToLower().Contains(search.ToLower())
                                       || doctor.FirstName.ToLower().Contains(search.ToLower()));
            }

            return View(model);
        }
    }
}
