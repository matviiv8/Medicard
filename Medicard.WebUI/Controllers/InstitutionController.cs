using Medicard.Services.Services.Interfaces;
using Medicard.Services.ViewModels.Institution;
using Medicard.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Medicard.WebUI.Controllers
{
    public class InstitutionController : Controller
    {
        private readonly IInstitutionService _institutionService;
        private readonly IDoctorService _doctorService;
        private readonly IHeadDoctorService _headDoctorService;

        public InstitutionController(IInstitutionService institutionService, IDoctorService doctorService, IHeadDoctorService headDoctorService)
        {
            this._institutionService = institutionService;
            this._doctorService = doctorService;
            this._headDoctorService = headDoctorService;
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

            if(this.User.IsInRole("Head doctor"))
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var headDoctor = _headDoctorService.GetByUserId(userId);

                viewModel.CurrentHeadDoctor = headDoctor;
            }

            return View(viewModel);
        }

        [Authorize(Roles="Doctor")]
        public async Task<IActionResult> JoinToInstitution(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var currentDoctor = this._doctorService.GetByUserId(userId);

            await this._institutionService.JoinToInstitution(currentDoctor, id);

            return this.RedirectToAction("AllInstitutions", "Institution");
        }
    }
}
