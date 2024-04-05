using Business.Concrete;
using Business.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new EfCategoryRepository();
        public IActionResult Index()
        {
            var categories = categoryManager.GetAll();
            return View(categories);
        }

        public IActionResult DeleteCategory(int id)
        {
            var category = categoryManager.GetById(id);
            categoryManager.TAdd(category);
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(category);
            if (results.IsValid)
            {
                categoryManager.TAdd(category);
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = categoryManager.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            categoryManager.TAdd(category);
            return RedirectToAction("Index", "Category");
        }
    }
}
