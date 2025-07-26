using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tasheel.BLL.Models;
using Tasheel.DAL.Extend;

namespace Tasheel.PL.Controllers
{
   
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        //public IActionResult Registration()
        //{
        //    return View();
        //}
        //public IActionResult Login()
        //{
        //    return View();
        //} 
        //public IActionResult ForgotPassword()
        //{
        //    return View();
        //}

        // GET: /Account/Register
        [HttpGet]
        [Microsoft.AspNetCore.Authorization.AllowAnonymous] // Allow anonymous access to the registration page
        public IActionResult Register()
        {
            ViewBag.role = new SelectList(_roleManager.Roles.ToList(), "Name", "Name");

            return View();
        }

        // POST: /Account/Register
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, IsAgree = model.IsAgree };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // ✅ Assign a role after user creation
                    await _userManager.AddToRoleAsync(user, model.role); // Change to your desired role

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


        // GET: /Account/Login
        [HttpGet]
        [Microsoft.AspNetCore.Authorization.AllowAnonymous] // Allow anonymous access to the login page
        public IActionResult Login(string returnUrl = null)
        {
            // Store the return URL so we can redirect back after successful login
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == model.Email);
                // بدل PhoneNumber، استخدم الخاصية التي تخزن الرقم في قاعدة بياناتك

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "المستخدم غير موجود.");
                    return View(model);
                }

                // Attempt to sign in the user
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                // lockoutOnFailure: false means we won't lock out the user after a certain number of failed attempts for now.
                // In a production app, you might want to enable this.

                if (result.Succeeded)
                {
                    // Redirect to the original URL if provided, otherwise to Home
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        
                        return RedirectToAction("Index", "Home");
                    }
                }
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "Account locked out. Please try again later.");
                    // You might want to redirect to a specific "LockedOut" view
                    return View(model);
                }
                if (result.IsNotAllowed)
                {
                    ModelState.AddModelError(string.Empty, "Login not allowed. Account may not be confirmed.");
                    // You might want to redirect to a specific "NotAllowed" view (e.g., email confirmation required)
                    return View(model);
                }
                else
                {
                    // If login failed, add a generic error
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt.");
                    return View(model);
                }
            }
            // If ModelState is not valid, return the view with validation errors
            return View(model);
        }

        // POST: /Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home"); // Redirect to home page after logout
        }

        // GET: /Account/AccessDenied
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
