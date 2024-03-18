using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal
    {
        List<Category> GetList();
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
        Category GetById(int id);
    }
}
