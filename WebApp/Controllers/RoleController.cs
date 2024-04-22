using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Identity;

namespace WebApp.Controllers
{
    public class RoleController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRole(RoleModel model)
        {
            return View();
        }
    }
}
