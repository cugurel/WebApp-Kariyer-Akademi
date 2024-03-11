using Entity.Concrete;
using Entity.Concrete.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var result = (from mv in context.Movies
                            join ct in context.Categories on mv.CategoryId equals ct.Id
                            select new MovieCategoryDto
                            {
                                Id = mv.Id,
                                CategoryId = mv.CategoryId,
                                Director = mv.Director,
                                ImageUrl = mv.ImageUrl,
                                ImdbRate = mv.ImdbRate,
                                Name = mv.Name,
                                CategoryName = ct.Name
                            });
                
            return View(result);
            
        }
    }
}