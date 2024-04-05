using Business.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
    public class CategoryList : ViewComponent
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());

        public IViewComponentResult Invoke()
        {
            var categories = categoryManager.GetList();
            return View(categories); 
        }
    }
}
