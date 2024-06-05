using Business.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class InterfaceController : Controller
    {
        IMovieService _movieService;
        Context c = new Context();
        public InterfaceController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            var movies = _movieService.GetMoviesWithCategory();

            ViewBag.TopRatedMovies = c.Movies.Where(x => x.CategoryId == 13).ToList();
            ViewBag.MostCommentedMovies = c.Movies.Where(x => x.CategoryId == 14).ToList();
            return View(movies);
        }
    }
}
