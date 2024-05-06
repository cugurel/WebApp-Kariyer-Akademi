using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp.Identity;
using WebApp.Models.Identity;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        UserManager<User> _userManager;
        SignInManager<User> _signinManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signinManager)
        {
            _userManager = userManager;
            _signinManager = signinManager;
        }

        [Authorize]
        public async Task<IActionResult> UserDetail()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            return View(user);
        }

        [Authorize]
        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = new User
            {
                FirstName = model.FirstName,
                Lastname = model.LastName,
                UserName = model.UserName,
                Email = model.Email
            };

            var userWithEmail = await _userManager.FindByEmailAsync(user.Email);
            if (userWithEmail != null)
            {
                TempData["EmailError"] = "Bu email ile bir kullanıcı zaten var";
                return View();
            }

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                TempData["SuccessReg"] = "Kayıt başarılı";
                return View();
            }
            return View();
        }
    }
}
