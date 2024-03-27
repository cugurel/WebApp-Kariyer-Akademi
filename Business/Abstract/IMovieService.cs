using Entity.Concrete;
using Entity.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMovieService
    {
        void MovieAdd(Movie movie);
        void MovieDelete(Movie movie);
        void MovieUpdate(Movie movie);
        List<Movie> GetList();
        List<MovieCategoryDto> GetMoviesWithCategory();
        Movie GetById(int id);
    }
}
