using Entity.Concrete;
using Entity.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMovieDal : IGenericDal<Movie>
    {
        List<MovieCategoryDto> GetMovieDto();
    }
}
