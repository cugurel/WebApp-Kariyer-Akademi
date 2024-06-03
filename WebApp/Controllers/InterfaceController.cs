using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class InterfaceController : Controller
    {
        IMovieService _movieService;
        public InterfaceController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            var movies = _movieService.GetMoviesWithCategory();
            return View(movies);
        }
    }
}
