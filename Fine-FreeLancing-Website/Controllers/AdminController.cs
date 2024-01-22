using Fine_FreeLancing_Website.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

namespace Fine_FreeLancing_Website.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<User> userManager;

        public AdminController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(userManager.Users);
        }


        [Route("asu")]
        [HttpGet]
        public IActionResult Signup() => View();

        [Route("asu")]
        [HttpPost]
        public async Task<IActionResult> Signup(AdminVM avm)
        {
                
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = avm.UserName,
                    Email = avm.Email,
                    FullName = avm.FullName,
                    Gender = avm.Gender
                };

                IdentityResult result = await userManager.CreateAsync(user, avm.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user,"Admin");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(avm);
        }
       

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            User? user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                var result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        
    }
}
