using Medicard.Services.Services;
using Medicard.Services.ViewModels.Institution;
using Medicard.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Medicard.WebUI.Controllers
{
    public class InstitutionController : Controller
    {
        private readonly IInstitutionService _institutionService;
        private readonly IDoctorService _doctorService;

        public InstitutionController(IInstitutionService institutionService, IDoctorService doctorService)
        {
            _institutionService = institutionService;
            _doctorService = doctorService;
        }

        public IActionResult AllInstitutions(string search, int page = 1)
        {
            ViewData["CurrentFilter"] = search;

            var institutions = this._institutionService.AllInstitutions();

            if (!string.IsNullOrEmpty(search))
            {
                institutions = institutions.Where(institution => institution.Name.ToLower().Contains(search.ToLower()));
            }

            int pageSize = 10;
            var count = institutions.Count();
            var items = institutions.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pagingInfo = new PageViewModel(count, page, pageSize);
            ShowAllInstitutionsViewModel viewModel = new ShowAllInstitutionsViewModel
            {
                PagingInfo = pagingInfo,
                AllInstitutions = items,
            };

            return View(viewModel);
        }

        public async Task<IActionResult> JoinToInstitution(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var currentDoctor = this._doctorService.GetById(userId);

            await this._institutionService.JoinToInstitution(currentDoctor, id);

            return this.RedirectToAction("AllInstitutions", "Institution");
        }
    }
}
