using DataAccessLayer.Concrete;
using Entity.Concrete;
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

            Context c = new Context();
            var userImage = c.UserImages.Where(x => x.UserId == userId).FirstOrDefault();

            if(userImage == null)
            {
                ViewBag.Image = "/template/assets/img/avatars/1.png";
            }
            else
            {
                ViewBag.Image = "/Images/Users/"+userImage.FileUrl;
            }

            
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

        [HttpPost]
        public async Task<IActionResult> AddProfileImage(UserImage userImage)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userImage.File != null)
            {
                var item = userImage.File;
                var extent = Path.GetExtension(item.FileName);
                var randomName = ($"{Guid.NewGuid()}{extent}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\Users", randomName);


                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                }
                userImage.UserId = userId;
                userImage.FileUrl = randomName;
                Context c = new Context();
                c.UserImages.Add(userImage);
                c.SaveChanges();
                return Redirect("UserDetail/"+userId);
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
