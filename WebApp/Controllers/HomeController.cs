using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var movies = c.Movies.ToList();
            return View(movies);
        }
    }
}