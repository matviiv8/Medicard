using Medicard.Domain.Astract.Repositories;
using Medicard.Domain.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medicard.WebUI.Controllers
{
    public class DoctorController : Controller
    {
        private DoctorRepository repository;
        public DoctorController(DoctorRepository repository)
        {

            this.repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
