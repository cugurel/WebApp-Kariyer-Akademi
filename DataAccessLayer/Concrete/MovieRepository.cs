using DataAccessLayer.Abstract;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class MovieRepository : IMovieDal
    {
        public void Delete(Movie t)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetAll()
        {
            throw new NotImplementedException();
        }

        public Movie GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<MovieCategoryDto> GetMovieDto()
        {
            throw new NotImplementedException();
        }

        public void Insert(Movie t)
        {
            throw new NotImplementedException();
        }

        public void Update(Movie t)
        {
            throw new NotImplementedException();
        }
    }
}
