using Medicard.Domain.Astract;
using Medicard.Domain.Entities;
using Medicard.Services.Services;
using Medicard.Services.ViewModels.Admin;
using Medicard.Services.ViewModels.Institution;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Medicard.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IInstitutionService _institutionService;

        public AdminController(IAdminService adminService , IInstitutionService institutionService)
        {
            this._adminService = adminService;
            this._institutionService = institutionService;
        }

        public IActionResult CreateDoctor()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateDoctorViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this._adminService.CreateDoctor(model);

            return this.RedirectToAction("AllDoctors", "Doctor");
        }

        public IActionResult DeleteDoctor(string id)
        {
            this._adminService.DeleteDoctor(id);

            return this.RedirectToAction("AllDoctors", "Doctor");
        }

        public IActionResult CreateInstitution()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateInstitution(InstitutionViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this._adminService.CreateInstitution(model);

            return this.RedirectToAction("AllInstitutions", "Institution");
        }

        public IActionResult DeleteInstitution(int id)
        {
            this._adminService.DeleteInstitution(id);

            return this.RedirectToAction("AllInstitutions", "Institution");
        }

        public IActionResult ChangeInstitution(int id)
        {
            var institution = _institutionService.GetByIdReturnViewModel(id);
            return this.View(institution);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeInstitution(InstitutionViewModel model,int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this._adminService.ChangeInstitution(model, id);

            return this.RedirectToAction("AllInstitutions", "Institution");
        }
    }
}
