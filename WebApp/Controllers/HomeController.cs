using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Movie> movies = new List<Movie>();

            Movie movie = new Movie();
            movie.Id = 1;
            movie.Name = "Kill Bill";
            movie.Director = "Quantin Tarantino";
            movie.ImdbRate = 10;
            movie.ImageUrl = "~/Images/online_killbill.jpg";

            Movie movie1 = new Movie();
            movie1.Id = 2;
            movie1.Name = "Pulp Fiction";
            movie1.Director = "Quantin Tarantino";
            movie1.ImdbRate = 10;
            movie1.ImageUrl = "~/Images/pulpfic.jpg";

            Movie movie2 = new Movie();
            movie2.Id = 3;
            movie2.Name = "Karayip Korsanları";
            movie2.Director = "Unknown";
            movie2.ImdbRate = 9;
            movie2.ImageUrl = "~/Images/karayip.jpg";

            movies.Add(movie);
            movies.Add(movie1);
            movies.Add(movie2);
            return View(movies);
        }

        
    }
}