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
    public class DealerManager : IDealerService
    {
        IDealerDal _dealerDal;

        public DealerManager(IDealerDal dealerDal)
        {
            _dealerDal = dealerDal;
        }

        public void Add(Dealer t)
        {
            _dealerDal.Insert(t);
        }

        public void Delete(Dealer t)
        {
            _dealerDal.Delete(t);
        }

        public List<Dealer> GetAll()
        {
            return _dealerDal.GetAll();
        }

        public Dealer GetById(int id)
        {
            return _dealerDal.GetById(id);
        }

        public void Update(Dealer t)
        {
            _dealerDal.Update(t);
        }
    }
}
