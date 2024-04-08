using Business.Concrete;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());

        /// <summary>
        /// Tüm kategorileri listeler.
        /// </summary>
        [HttpGet("AllCategories")]
        public IActionResult GetAllCategory()
        {
            var values = categoryManager.GetAll();
            if(values == null)
            {
                return BadRequest("Veri bulunamadı!!!");
            }
            return Ok(values);
        }


        /// <summary>
        /// Id girilmesi zorunludur, id ye göre kategori getirir.
        /// </summary>
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var value = categoryManager.GetById(id);
            if (value == null)
            {
                return BadRequest("Veri bulunamadı!!!");
            }
            return Ok(value);
        }

        [HttpPost("AddNewCategory")]
        public IActionResult AddCategory(Category category)
        {
            categoryManager.Add(category);
            return Ok(category);
        }

        [HttpPut("UpdateCategory")]
        public IActionResult UpdateCategory(Category category)
        {
            categoryManager.Update(category);
            return Ok(category);
        }

        [HttpDelete("DeleteCategory")]
        public IActionResult DeleteCategory(int id)
        {
            var value = categoryManager.GetById(id);
            categoryManager.Delete(value);
            return Ok();
        }
    }
}
