using DataAccessLayer.Concrete;
using Entity.Concrete;
using Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApp.Identity;
using WebApp.Models.Identity;

namespace WebApp.Controllers
{

    public class AuthController : Controller
    {
        UserManager<User> _userManager;
        SignInManager<User> _signInManager;
        Context c = new Context();

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
             _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                TempData["LoginError"] = "Bu email ile kayıtlı kullanıcı bulunamadı!";
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {
                var crypt = new System.Security.Cryptography.SHA256Managed();
                var hash = new System.Text.StringBuilder();
                byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
                foreach (byte theByte in crypto)
                {
                    hash.Append(theByte.ToString("x2"));
                }

                model.Password = hash.ToString();

                Log log = new Log();
                
                log.UserId = user.Id;
                log.Status = true;
                log.Process = "Login İşlemi";
                log.Date = DateTime.UtcNow;
                log.Parameter = JsonConvert.SerializeObject(model);
                c.Logs.Add(log);
                c.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
