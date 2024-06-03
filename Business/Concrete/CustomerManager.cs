using Business.Abstract;
using DataAccessLayer.Abstract;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void Add(Customer t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer t)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAllCustomer()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            return  _customerDal.GetById(id);
        }

        public List<CustomerDto> GetCustomerDto()
        {
            return _customerDal.GetCustomerDto();
        }

        public void Update(Customer t)
        {
            throw new NotImplementedException();
        }
    }
}
