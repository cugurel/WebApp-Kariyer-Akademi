using Business.Concrete;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        MovieManager movieManager = new MovieManager(new EfMovieRepository());

        [HttpGet("AllMovies")]
        public IActionResult GetAllMovie()
        {
            var values = movieManager.GetMoviesWithCategory();
            if (values == null)
            {
                return BadRequest("Veri bulunamadı!!!");
            }
            return Ok(values);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = movieManager.GetById(id);
            if (value == null)
            {
                return BadRequest("Veri bulunamadı!!!");
            }
            return Ok(value);
        }

        [HttpPost("AddNewMovie")]
        public IActionResult AddMovie(Movie movie)
        {
            movieManager.MovieAdd(movie);
            return Ok(movie);
        }

        [HttpPut("UpdateMovie")]
        public IActionResult UpdateMovie(Movie movie)
        {
            movieManager.MovieUpdate(movie);
            return Ok(movie);
        }

        [HttpDelete("DeleteMovie")]
        public IActionResult DeleteMovie(int id)
        {
            var value = movieManager.GetById(id);
            movieManager.MovieDelete(value);
            return Ok();
        }
    }
}
