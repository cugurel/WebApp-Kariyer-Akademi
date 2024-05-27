using Business.Abstract;
using DataAccessLayer.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerService _customerService;
        Context c = new Context();
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public JsonResult GetTown(int p)
        {
            var towns = (from x in c.Towns where x.CityId == p
                         select new
                         {
                             Text = x.Name,
                             Value = x.Id.ToString()
                         }).ToList();

            return Json(towns);
        }


        public IActionResult Index()
        {
            var customers = _customerService.GetCustomerDto();
            return View(customers);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            
            List<SelectListItem> cityList = (from x in c.Cities.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.Id.ToString()
                                                    }).ToList();

            ViewBag.City = cityList;


            List<SelectListItem> townList = (from x in c.Towns.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.Id.ToString()
                                             }).ToList();

            ViewBag.Town = townList;

            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            List<SelectListItem> cityList = (from x in c.Cities.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.Id.ToString()
                                             }).ToList();

            ViewBag.City = cityList;


            List<SelectListItem> townList = (from x in c.Towns.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.Id.ToString()
                                             }).ToList();

            ViewBag.Town = townList;

            _customerService.Add(customer);
            return RedirectToAction("Index","Customer");
        }


        public IActionResult DeleteCustomer(int id)
        {
            var customer = _customerService.GetById(id);
            _customerService.Delete(customer);
            return RedirectToAction("Index", "Customer");
        }
    }
}
