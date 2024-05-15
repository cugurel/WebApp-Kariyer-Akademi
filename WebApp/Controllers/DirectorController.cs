using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using X.PagedList;

namespace WebApp.Controllers
{
    public class DirectorController : Controller
    {
        public async Task<IActionResult> Index(int page = 1)
        {
            using var httpClient = new HttpClient();
            var result = await httpClient.GetAsync("https://localhost:7101/api/Director/AllDirectors");

            var jsonString = result.Content.ReadAsStringAsync().Result;

            var directors = JsonConvert.DeserializeObject<List<Director>>(jsonString);
            var directorList = directors.ToList().ToPagedList(page,2);
            return View(directorList);
        }
    }
}
