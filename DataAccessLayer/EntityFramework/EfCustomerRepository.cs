using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCustomerRepository : GenericRepository<Customer>, ICustomerDal
    {
        Context context = new Context();
        public List<CustomerDto> GetCustomerDto()
        {
            var result = (from mv in context.Customers
                            join ct in context.Cities on mv.CityId equals ct.Id
                            join tw in context.Towns on mv.TownId equals tw.Id
                            select new CustomerDto
                            {
                                Id = mv.Id,
                                Name = mv.Name,
                                Surname = mv.Surname,
                                CityName = ct.Name,
                                TownName = tw.Name
                            });

            return result.ToList();
            }
    }
}
