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
        public List<MovieCategoryDto> GetMovieDto()
        {
            throw new NotImplementedException();
        }
    }
}
