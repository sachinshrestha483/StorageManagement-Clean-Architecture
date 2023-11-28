using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using NuGet.Packaging.Signing;
using StorageManagement.Core.Application.Abstractions;
using StorageManagement.Core.Application.Common.Utility;
using StorageManagement.Presentation.Web.Models.ViewModels;

namespace StorageManagement.Presentation.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AcessDenied()
        {
            return View();
        }

        public IActionResult Login(string? returnUrl)
        {
            returnUrl ??= Url.Content("~/");

            var viewModel = new LoginViewModel()
            {
                RedirectUrl = returnUrl,
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager
                    .PasswordSignInAsync(viewModel.UserName,viewModel.Password,isPersistent:true,lockoutOnFailure:false);

                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(viewModel.RedirectUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return LocalRedirect(viewModel.RedirectUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Register()
        {
            if (!(await _roleManager.RoleExistsAsync(StaticData.RoleSuperAdmin)))
            {
                await _roleManager.CreateAsync(new IdentityRole(StaticData.RoleSuperAdmin));
                await _roleManager.CreateAsync(new IdentityRole(StaticData.RoleAdmin));
            }

            var viewModel = new RegisterViewModel()
            {
                RoleList = _roleManager.Roles.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Name
                })
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = viewModel.Name,
                    Email = viewModel.Email,
                    NormalizedEmail = viewModel.Email.ToUpper(),
                    EmailConfirmed = true,
                };

                var result = await _userManager.CreateAsync(user, viewModel.Password);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(viewModel.Role))
                    {
                        await _userManager.AddToRoleAsync(user, viewModel.Role);
                    }

                    await _signInManager.SignInAsync(user,true);

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

            viewModel.RoleList = _roleManager.Roles.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Name
            });

            return View(viewModel);
        }

    }
}
