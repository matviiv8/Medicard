using Medicard.Domain.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medicard.WebUI.Controllers
{
    public class DoctorController : Controller
    {
        private readonly MedicardDbContext _context;
        public DoctorController(MedicardDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patients.ToListAsync());
        }
    }
}
