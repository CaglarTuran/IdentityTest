using IdentityTest.Models;
using IdentityTest.VM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTest.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(Register model)
        {
            User user = new User { Email = model.Email, UserName = model.UserName, TuttuguTakim = model.TuttuguTakim };


            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded) 
            {
                ViewBag.Info = "Kayıt Başarılı";

            }
            else
            {
                ViewBag.Info = result.Errors.Select(a => a.Description).ToList();
            }

            return View(model);
        }
    }
}
