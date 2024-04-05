using Business.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
    public class CategoryList : ViewComponent
    {
        CategoryManager categoryManager = (new EfCategoryRepository());

        public IViewComponentResult Invoke()
        {
            var categories = categoryManager.GetAll();
            return View(categories); 
        }
    }
}
