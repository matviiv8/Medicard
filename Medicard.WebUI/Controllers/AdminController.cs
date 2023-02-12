using Medicard.Domain.Astract;
using Medicard.Domain.Entities;
using Medicard.Services.Services.Interfaces;
using Medicard.Services.ViewModels.Admin;
using Medicard.Services.ViewModels.Institution;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Medicard.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IInstitutionService _institutionService;
        private readonly UserManager<User> _userManager;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly IHeadDoctorService _headDoctorService;

        public AdminController(
            IAdminService adminService,
            IInstitutionService institutionService,
            UserManager<User> userManager,
            IPatientService patientService,
            IDoctorService doctorService,
            IHeadDoctorService headDoctorService)
        {
            this._adminService = adminService;
            this._institutionService = institutionService;
            this._userManager = userManager;
            this._patientService = patientService;
            this._doctorService = doctorService;
            this._headDoctorService = headDoctorService;
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
            var allHeadDoctorsWithoutInstitution = _headDoctorService.AllHeadDoctors().Where(headDoctor => headDoctor.InstitutionId == null);

            ViewBag.ListHeadDoctorsWithoutInstitution = CompletingListOfHeadDoctors(allHeadDoctorsWithoutInstitution);

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateInstitution(InstitutionViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            if (this.User.IsInRole("Admin"))
            {
                await this._adminService.CreateInstitution(model);

                if (model.HeadDoctorId != null)
                {
                    var institution = _institutionService.GetLast();
                    this._adminService.CommissionHeadDoctor(model.HeadDoctorId, institution.Id);
                }
            }
            else
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var headDoctor = _headDoctorService.GetByUserId(userId);

                await this._adminService.CreateInstitution(model, userId);

                var institution = _institutionService.GetLast();
                this._adminService.CommissionHeadDoctor(headDoctor.Id, institution.Id);
            }

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
            var allHeadDoctorsWithoutInstitution = _headDoctorService.AllHeadDoctors().Where(headDoctor => headDoctor.InstitutionId == null);
            var currentHeadDoctor = _headDoctorService.AllHeadDoctors().Where(headDoctor => headDoctor.InstitutionId == id).FirstOrDefault();

            ViewBag.ListHeadDoctorsWithoutInstitution = CompletingListOfHeadDoctors(allHeadDoctorsWithoutInstitution);

            if (this.User.IsInRole("Admin") && currentHeadDoctor != null)
            {
                this._adminService.DegradeHeadDoctor(currentHeadDoctor.Id);
            }

            return this.View(institution);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeInstitution(InstitutionViewModel model,int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }


            if (this.User.IsInRole("Admin"))
            {
                await this._adminService.ChangeInstitution(model, id);

                if (model.HeadDoctorId != null)
                {
                    this._adminService.CommissionHeadDoctor(model.HeadDoctorId, id);
                }
            }
            else
            {
                await this._adminService.ChangeInstitution(model, id, true);
            }

            return this.RedirectToAction("AllInstitutions", "Institution");
        }

        [HttpGet]
        public IActionResult Statistics()
        {
            var usersCount = _userManager.Users.Count();
            var doctorsCount = _doctorService.AllDoctors().Count();
            var patientsCount = _patientService.AllPatients().Count();

            return this.View(new StatisticsViewModel
            {
                UsersCount = usersCount,
                DoctorsCount = doctorsCount,
                PatientsCount = patientsCount,
            });
        }

        private List<SelectListItem> CompletingListOfHeadDoctors(IEnumerable<HeadDoctor> allHeadDoctors)
        {
            var headDoctorsSelectList = new List<SelectListItem>();

            foreach (var headDoctor in allHeadDoctors)
            {
                if (headDoctor.Doctor == null)
                {
                    var doctor = _doctorService.GetById(headDoctor.DoctorId);
                    headDoctorsSelectList.Add(new SelectListItem { Text = doctor.ToString(), Value = headDoctor.Id.ToString() });
                }
                else
                {
                    headDoctorsSelectList.Add(new SelectListItem { Text = headDoctor.Doctor.ToString(), Value = headDoctor.Id.ToString() });
                }
            }

            return headDoctorsSelectList;
        }
    }
}
