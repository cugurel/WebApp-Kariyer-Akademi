using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [HttpGet]
        public IActionResult AddMovie()
        {
            List<SelectListItem> categoryOfMovie = (from c in c.Categories.ToList()
                                                      select new SelectListItem
                                                      {
                                                          Text = c.Name,
                                                          Value = c.Id.ToString()
                                                      }).ToList();

            ViewBag.Category = categoryOfMovie;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(Movie movie)
        {
            if (movie.File != null)
            {
                var item = movie.File;
                var extent = Path.GetExtension(item.FileName);
                var randomName = ($"{Guid.NewGuid()}{extent}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", randomName);


                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                }

                movie.ImageUrl = randomName;
                c.Movies.Add(movie);
                c.SaveChanges();
            }
            else
            {
                c.Movies.Add(movie);
                c.SaveChanges();
            }

            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult UpdateMovie(int id)
        {
            var value = c.Movies.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateMovie(Movie movie)
        {
            c.Movies.Update(movie);
            c.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
