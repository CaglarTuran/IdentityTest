using IdentityTest.Models;
using IdentityTest.VM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace IdentityTest.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Index(Register model)
        {

            User user = new User { Email = model.Email, UserName = model.UserName, TuttuguTakim = model.TuttuguTakim };


            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                ViewBag.Info = "Kayıt Başarılı";

            }
            else
            {
                ViewBag.Info = Convert.ToString(string.Join("<br>", result.Errors.Select(a => a.Description)));
                
            }

            return View(model);
        }
    }
}
