using Medicard.Domain.Concrete;
using Medicard.Domain.Entities;
using Medicard.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Medicard.WebUI.Areas.Account.Controllers
{
    public class AccountController : Controller
    {
        private MedicardDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = new User { UserName = model.Email, Email = model.Email };

            if (ModelState.IsValid)
            {
                var hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<IdentityUser>();

                if (PasswordVerificationResult.Failed == hasher.VerifyHashedPassword(
                    new IdentityUser(user.Id.ToString()), 
                    _signInManager.UserManager.Users.FirstOrDefault(x => x.Email == model.Email).PasswordHash,
                    model.Password))
                {
                    ModelState.AddModelError("Password", "password is wrong");
                }

            }
            else
            {
                ModelState.AddModelError("Email", "email or password invalid");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
