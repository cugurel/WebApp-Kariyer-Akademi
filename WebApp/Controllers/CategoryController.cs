using DataAccessLayer.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var categories = c.Categories.ToList();
            return View(categories);
        }

        public IActionResult DeleteCategory(int id)
        {
            var category = c.Categories.Find(id);
            c.Categories.Remove(category);
            c.SaveChanges();
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            
            c.Categories.Add(category);
            c.SaveChanges();
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = c.Categories.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            c.Categories.Update(category);
            c.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
    }
}
