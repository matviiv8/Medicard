﻿using Medicard.Domain.Concrete;
using Medicard.Domain.Entities;
using Medicard.Services.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Medicard.WebUI.Areas.Account.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private MedicardDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, MedicardDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
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
                var user = new User { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    _context.Patients.Add(new Patient { UserId = user.Id, FirstName = user.FirstName, LastName = user.LastName, ContactNumber = model.PhoneNumber });

                    _userManager.AddToRoleAsync(user, "Patient").Wait();
                    await _context.SaveChangesAsync();
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
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            var loginModel = new LoginViewModel()
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            return View(loginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (await _userManager.FindByEmailAsync(model.Email) != null)
            {
                if (ModelState.IsValid)
                {
                    var user = _userManager.Users.Where(u => u.Email == model.Email).FirstOrDefault();
                    var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Password wrong");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Not found this login");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { ReturnUrl = returnUrl });

            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> ExternalLoginCallback(string? returnUrl = null, string? remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            var loginModel = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList(),
            };

            if (remoteError != null)
            {
                return View(nameof(Login), loginModel);
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return View(nameof(Login), loginModel);
            }

            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);

                if (email != null)
                {
                    var user = await _userManager.FindByEmailAsync(email);

                    if (user == null)
                    {

                        var registerExternalViewModel = new RegisterExternalViewModel
                        {
                            Email = email,
                            FirstName = info.Principal.FindFirstValue(ClaimTypes.GivenName),
                            LastName = info.Principal.FindFirstValue(ClaimTypes.Surname),
                            ReturnUrl = returnUrl,
                            LoginProvider = info.LoginProvider
                        };

                        return View(nameof(ExternalLoginRegister), registerExternalViewModel);
                    }

                    await _userManager.AddLoginAsync(user, info);
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnUrl);
                }

                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ExternalLoginRegister(RegisterExternalViewModel registerExternalViewModel)
        {
            string phoneNumber = registerExternalViewModel.PhoneNumber.Contains('+')
                ? registerExternalViewModel.PhoneNumber
                : $"{registerExternalViewModel.PhoneNumber.Remove(0, 1)}";

            var user = new User
            {
                Email = registerExternalViewModel.Email,
                FirstName = registerExternalViewModel.FirstName,
                LastName = registerExternalViewModel.LastName,
                PhoneNumber = phoneNumber,
                UserName = registerExternalViewModel.Email,
            };

            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                _context.Patients.Add(new Patient
                {
                    UserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    ContactNumber = user.PhoneNumber,
                    Gender = registerExternalViewModel.Gender,
                });

                _context.SaveChanges();

                _userManager.AddToRoleAsync(user, "Patient").Wait();
                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            if (registerExternalViewModel.ReturnUrl == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return LocalRedirect(registerExternalViewModel.ReturnUrl);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePassword)
        {
            changePassword.User = _userManager.Users.Where(user => user.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).First();
            var result = await _userManager.ChangePasswordAsync(changePassword.User, changePassword.CurrentPassword, changePassword.NewPassword);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult DeletePersonalData()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeletePersonalData(DeletePersonalDataViewModel deletePersonalDataViewModel)
        {
            var deleteUser = _userManager.Users.FirstOrDefault(user => user.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (VerifyPasswordHash(deleteUser, deletePersonalDataViewModel.Password))
            {
                var patient = _context.Patients.FirstOrDefault(p => p.UserId == deleteUser.Id);

                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();

                var result = await _userManager.DeleteAsync(deleteUser);

                if (result.Succeeded)
                {
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("Error");
                }
            }

            return View("Error");
        }

        private bool VerifyPasswordHash(User user, string newPassword)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            var identityUser = new IdentityUser(user.Id.ToString());

            var result = hasher.VerifyHashedPassword(identityUser, user.PasswordHash, newPassword);

            return result == PasswordVerificationResult.Success;
        }
    }
}