using Medicard.Domain.Astract;
using Medicard.Domain.Entities;
using Medicard.Services.Services;
using Medicard.Services.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Medicard.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            this._adminService = adminService;
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
    }
}
