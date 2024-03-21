using Business.Abstract;
using DataAccessLayer.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        CategoryRepository categoryRespository = new CategoryRepository();
        public void CategoryAdd(Category category)
        {
            categoryRespository.Insert(category);
        }

        public void CategoryUpdate(Category category)
        {
            categoryRespository.Update(category);
        }

        public void CategoryDelete(Category category)
        {
            categoryRespository.Delete(category);
        }

        public Category GetById(int id)
        {
            return categoryRespository.GetById(id);
        }

        public List<Category> GetList()
        {
            return categoryRespository.GetAll();
        }
    }
}
