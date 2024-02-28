using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class MovieController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MovieDetail(int id)
        {
            var movie = c.Movies.Where(x => x.Id == id).FirstOrDefault();
            return View(movie);
        }


        public IActionResult DeleteMovie(int id)
        {
            var movie = c.Movies.Find(id);
            c.Movies.Remove(movie);
            c.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}
