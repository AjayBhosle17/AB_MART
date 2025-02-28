using DAL.Entities;
using DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WEB_UI_Client.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _SignInManager;
        private readonly UserManager<IdentityUser> _UserManager;


        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager = null)
        {
            _SignInManager = signInManager;
            _UserManager = userManager;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {

            var result = _SignInManager.PasswordSignInAsync(login.Email, login.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.IsCompleted)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(login);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel register)
        {
           
           // var registration = _UserManager.CreateAsync(user, register.Password);
            return View();
        }
    }
}
