using Business.Abstract;
using Business.Concrete;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        IDirectorService _directorService;

        public DirectorController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        /// <summary>
        /// Tüm yönetmenleri listeler.
        /// </summary>
        [HttpGet("AllDirectors")]

        public IActionResult GetAllDirectors()
        {
            var values = _directorService.GetAll();
            if (values == null)
            {
                return BadRequest("Veri bulunamadı!!!");
            }
            return Ok(values);
        }


        /// <summary>
        /// Id girilmesi zorunludur, id ye göre yönetmen getirir.
        /// </summary>
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var value = _directorService.GetById(id);
            if (value == null)
            {
                return BadRequest("Veri bulunamadı!!!");
            }
            return Ok(value);
        }

        /// <summary>
        /// Yönetmen ekle
        /// </summary>
        [HttpPost("AddNewDirector")]
        public IActionResult AddDirector(Director director)
        {
            _directorService.Add(director);
            return Ok(director);
        }

        /// <summary>
        /// Yönetmen güncelle
        /// </summary>
        [HttpPut("UpdateDirector")]
        public IActionResult UpdateDirector(Director director)
        {
            _directorService.Update(director);
            return Ok(director);
        }

        /// <summary>
        /// Yönetmen sil
        /// </summary>
        [HttpDelete("DeleteDirector")]
        public IActionResult DeleteDirector(int id)
        {
            var value = _directorService.GetById(id);
            _directorService.Delete(value);
            return Ok();
        }
    }
}
