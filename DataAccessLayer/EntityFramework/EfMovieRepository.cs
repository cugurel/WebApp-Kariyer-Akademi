using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMovieRepository : GenericRepository<Movie>, IMovieDal
    {
        Context context = new Context();
        public List<MovieCategoryDto> GetMovieDto()
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

            return result.ToList();
        }
    }
}
