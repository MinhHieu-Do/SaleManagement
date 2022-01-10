using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp.SaleManagement.Models;
using WebApp.SaleManagement.ViewModels;

namespace WebApp.SaleManagement.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly INotyfService _notyfService;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,INotyfService notyf)
        {
            _notyfService = notyf;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName=model.FullName,
                Address=model.Address,
                DateOfBirth=model.DateOfBirth
            };
            if (model.UserName == null || model.UserName.Trim().Equals(""))
            {
                user.UserName = model.Email;
            }
            var success = await _userManager.CreateAsync(user, model.Password);
            if (success.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                await _signInManager.SignInAsync(user, isPersistent: false);
                
                _notyfService.Success("Success");
                return RedirectToAction("Index","Admin");
            }


            foreach (var error in success.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            _notyfService.Error("Failed");
            return View("Register");
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            LoginViewModel model = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins =(await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return NotFound();
            }

            var success = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (success.Succeeded)
            {
                _notyfService.Success("Sucess");
                return RedirectToAction("Index", "Admin");
            }
            LoginViewModel login = new LoginViewModel
            {
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            _notyfService.Error("Failed");
            return View("Login",login);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            
            return RedirectToAction("Login","Account");
        }


        public IActionResult AccessDenied()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View();
            }
            return RedirectToAction("Login","Account");
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            
            if (provider == null && provider=="")
            {
                return NotFound();
            }
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account",
                                new { ReturnUrl = returnUrl, provider=provider });
            var properties =_signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }
        [AllowAnonymous]
        public async Task<IActionResult>ExternalLoginCallback(string returnUrl = null, string remoteError = null,string provider="")
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            LoginViewModel loginViewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins =(await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");

                return View("Login", loginViewModel);
            }

            
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError(string.Empty, "Error loading external login information.");

                return View("Login", loginViewModel);
            }

            
            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider,
                info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (signInResult.Succeeded)
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
                        user = new ApplicationUser
                        {
                            UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email)                                                        
                        };
                        if (provider == "Google")
                            user.GoogleId = info.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
                        if (provider == "Facebook")
                            user.FaceBookId = info.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
                        await _userManager.CreateAsync(user);
                    }

                    await _userManager.AddToRoleAsync(user, "User");
                    await _userManager.AddLoginAsync(user, info);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    
                    return LocalRedirect(returnUrl);
                }

                

                return View("Error");
            }
        }
    }
}
