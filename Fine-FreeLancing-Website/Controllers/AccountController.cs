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

        [HttpGet]
        public IActionResult Login()
        {
            Login li = new Login();
            li.returnurl = "none";
            return View(li);
        }
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
        public IActionResult Loginurl(string path)
        {
            Login li = new Login();
            li.returnurl = path;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Loginurl(Login li)
        {
            return View(li);
        }

        public async Task<IActionResult> Logout(string returnUrl)
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}