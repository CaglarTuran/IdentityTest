using IdentityTest.Models;
using IdentityTest.VM;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace IdentityTest.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public HomeController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Register model)
        {

            User user = new User { Email = model.Email, UserName = model.UserName, TuttuguTakim = model.TuttuguTakim };


            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                ViewBag.Info = "Kayıt Başarılı";

            }
            else
            {
                ViewBag.Info = Convert.ToString(string.Join(" *** ", result.Errors.Select(a => a.Description)));

            }

            return View(model);
        }


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is not null)
            {
               var res =  await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (res.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }

            }

            ViewBag.Info = "Giriş Başarısız";
            return View();
        }

        public IActionResult Claims()
        {
            List<Claim> claims = User.Claims.ToList();

            return View(claims);
        }
    }
}
