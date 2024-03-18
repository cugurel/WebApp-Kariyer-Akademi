using DataAccessLayer.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class MovieRepository : IMovieDal
    {
        Context c = new Context();
        public void Add(Movie movie)
        {
            c.Movies.Add(movie);
            c.SaveChanges();
        }

        public void Delete(Movie movie)
        {
            c.Movies.Remove(movie);
            c.SaveChanges();
        }

        public Movie GetById(int id)
        {
            return c.Movies.Find(id);
        }

        public List<Movie> GetList()
        {
            return c.Movies.ToList();
        }

        public void Update(Movie movie)
        {
            c.Update(movie);
            c.SaveChanges();
        }
    }
}
