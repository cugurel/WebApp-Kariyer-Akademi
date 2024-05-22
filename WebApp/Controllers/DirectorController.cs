using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
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

        [HttpGet]
        public IActionResult AddDirector()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDirector(Director director)
        {
            var httpClient = new HttpClient();
            var jsonDirector = JsonConvert.SerializeObject(director);
            StringContent content = new StringContent(jsonDirector, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7101/api/Director/AddNewDirector", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Director");
            }
            return View();
        }
    }
}
