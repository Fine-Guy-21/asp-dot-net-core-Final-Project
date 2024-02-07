using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using System.Runtime.InteropServices;

using Fine_FreeLancing_Website.Models;
using System.Text.RegularExpressions;

namespace Fine_FreeLancing_Website.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Signup() => View();

        [HttpPost]
        public async Task<IActionResult> Signup(UserVM uservm)
        {
            if (ModelState.IsValid)
            {
                
                User user = new User
                {
                    UserName = uservm.UserName,
                    Email = uservm.Email,
                    FullName = uservm.FullName,
                    Gender = uservm.Gender
                };

                IdentityResult result = await userManager.CreateAsync(user, uservm.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, (uservm.Userrole).ToString());
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(uservm);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnurl)
        {
            Login li = new Login();
            li.Returnurl = returnurl;
            return View(li);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(Login li)
        {
            
            if (ModelState.IsValid)
            {
                User? user = await userManager.FindByEmailAsync(li.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager
                        .PasswordSignInAsync(user, li.Password, false, false);

                    if (result.Succeeded)
                    {
                        if (li.Returnurl != null)
                        {
                            return Redirect(li.Returnurl ?? "/"); 
                        }
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(nameof(li.Email), "Login Failed: Invalid Email or Password Combination");
                    RedirectToAction("Login");
                }
            }
            return View(li);
        }

        [HttpGet]
        public IActionResult Loginurl()
        {
            Login li = new Login();
            li.Returnurl = "none";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Loginurl(Login li)
        {
            if (ModelState.IsValid)
            {
                User? user = await userManager.FindByEmailAsync(li.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager
                        .PasswordSignInAsync(user, li.Password, false, false);

                    if (result.Succeeded)
                    {
                       
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(li.Email), "Login Failed: Invalid Email or Password Combination");
                        RedirectToAction("Loginurl");
                    }

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Login Failed: User not found"); 
                    RedirectToAction("Loginurl");
                }
                
            }
                return View(li);
        }

        public async Task<IActionResult> Logout(string returnUrl)
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}