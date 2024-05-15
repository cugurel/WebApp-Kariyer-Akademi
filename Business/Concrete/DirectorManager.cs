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
    public class DirectorManager : IDirectorService
    {
        IDirectorDal _directorDal;

        public DirectorManager(IDirectorDal directorDal)
        {
            _directorDal = directorDal;
        }

        public void Add(Director t)
        {
            _directorDal.Insert(t);
        }

        public void Delete(Director t)
        {
            _directorDal.Delete(t);
        }

        public List<Director> GetAll()
        {
            return _directorDal.GetAll();
        }

        public Director GetById(int id)
        {
            return _directorDal.GetById(id);
        }

        public void Update(Director t)
        {
            _directorDal.Update(t);
        }
    }
}
