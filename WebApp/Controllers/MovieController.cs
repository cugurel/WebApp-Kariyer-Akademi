using Business.Abstract;
using DataAccessLayer.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace WebApp.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MovieDetail(int id)
        {
            var movie = _movieService.GetById(id);
            return View(movie);
        }


        public IActionResult DeleteMovie(int id)
        {
            var movie = _movieService.GetById(id);
            _movieService.MovieDelete(movie);
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            Context c = new Context();
            List<SelectListItem> categoryOfMovie = (from x in c.Categories.ToList()
                                                      select new SelectListItem
                                                      {
                                                          Text = x.Name,
                                                          Value = x.Id.ToString()
                                                      }).ToList();

            ViewBag.Category = categoryOfMovie;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(Movie movie)
        {
            Context c = new Context();
            List<SelectListItem> categoryOfMovie = (from x in c.Categories.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.Id.ToString()
                                                    }).ToList();

            ViewBag.Category = categoryOfMovie;

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
                _movieService.MovieAdd(movie);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                _movieService.MovieAdd(movie);
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet]
        public async Task<IActionResult> UpdateMovie(int id)
        {

            //var httpClient = new HttpClient();
            //var responseMessage = await httpClient.GetAsync("https://localhost:7101/api/Movie/"+id);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
            //    var value = JsonConvert.DeserializeObject<Movie>(jsonEmployee);
            //    return View(value);
            //}

            Context c = new Context();
            List<SelectListItem> categoryOfMovie = (from x in c.Categories.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.Id.ToString()
                                                    }).ToList();

            ViewBag.Category = categoryOfMovie;

            var value = _movieService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMovie(Movie movie)
        {
            var currentMovie = _movieService.GetById(movie.Id);
            if (movie.File == null)
            {
                movie.ImageUrl = currentMovie.ImageUrl;
                _movieService.MovieUpdate(movie);
                return RedirectToAction("Index", "Home");
            }
            


            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", currentMovie.ImageUrl);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            
           

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
                _movieService.MovieUpdate(movie);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                _movieService.MovieUpdate(movie);
                return RedirectToAction("Index", "Home");
            }
            

            //try
            //{
            //    var httpClient = new HttpClient();
            //    var jsonMovie = JsonConvert.SerializeObject(movie);
            //    StringContent content = new StringContent(jsonMovie, Encoding.UTF8, "application/json");
            //    var responseMessage = await httpClient.
            //        PutAsync("https://localhost:7101/api/Movie/UpdateMovie", content);
            //    if (responseMessage.IsSuccessStatusCode)
            //    {
            //        return RedirectToAction("Index", "Home");
            //    }
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}

        }
    }
}
