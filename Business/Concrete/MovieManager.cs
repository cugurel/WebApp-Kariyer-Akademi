using Business.Abstract;
using DataAccessLayer.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MovieManager : IMovieService
    {
        IMovieDal _movieDal;

        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }

        public void MovieAdd(Movie movie)
        {
            _movieDal.Insert(movie);
        }

        public void MovieUpdate(Movie movie)
        {
            _movieDal.Update(movie);
        }

        public void MovieDelete(Movie movie)
        {
            _movieDal.Delete(movie);
        }

        public Movie GetById(int id)
        {
            return _movieDal.GetById(id);
        }

        public List<Movie> GetList()
        {
            return _movieDal.GetAll();
        }
    }
}
