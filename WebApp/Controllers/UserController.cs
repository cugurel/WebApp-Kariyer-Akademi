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
        [HttpGet]
        public async Task<IActionResult> MemberInfo(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                user.FirstName = model.Name;
                user.Lastname = model.Surname;
                user.PhoneNumber = model.Phone;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(user);
                }
            }
            return View();
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
