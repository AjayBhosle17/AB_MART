using DAL.Entities;
using DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace AB.Mart.Controllers
{

    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;



        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
            {
            LoginModel vm = new LoginModel();
            ViewData["returnUrl"] = returnUrl;
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                login.LoginStatus = "Invalid data. Please try again.";
                return View(login);
            }

            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                login.LoginStatus = "Invalid email or password.";
                return View(login);
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, login.Password, false, false);

            if (result.Succeeded)
            {
                login.LoginStatus = "Login Successful. Thank you!";

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }

            login.LoginStatus = "Invalid email or password.";
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(login);
        }

        [HttpGet]
        public IActionResult Register()
        {
            RegisterModel vm = new RegisterModel();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel register)
        {

            var user = new ApplicationUser
            {
                FirstName = register.applicationUser.FirstName,
                LastName = register.applicationUser.LastName,
                Email = register.Email,
                UserName = register.UserName,
                Address = register.applicationUser.Address,
                City = register.applicationUser.City
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (user != null)
            {
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
            }

            register.StatusMessage = "Registration unsuccessful: " + string.Join(" ", result.Errors.Select(e => e.Description));
            return View(register);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            //HttpContext.Session.Clear();
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }



    }


}