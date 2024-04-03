using DataAccessLayer.Concrete;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        Context context = new Context();
        public async Task<IActionResult> Index()
        {
            List<MovieCategoryDto> movies = new List<MovieCategoryDto>();
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage message = await client.
                    GetAsync("https://localhost:7101/api/Movie/AllMovies"))
                {
                    using (HttpContent content = message.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                        movies = JsonConvert.DeserializeObject<List<MovieCategoryDto>>(data);
                    }
                }
            }

            return View(movies);
        }


    }
}