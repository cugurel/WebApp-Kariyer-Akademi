using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMovieDal
    {
        //Bu fonksiyon imzası tüm filmleri listeler
        List<Movie> GetList();
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(Movie movie);
        Movie GetById(int id);
    }
}
