﻿using Business.Abstract;
using DataAccessLayer.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        ICustomerService _customerService;
        IDealerService _dealerService;
        Context c = new Context();
        public CustomerController(ICustomerService customerService, IDealerService dealerService)
        {
            _customerService = customerService;
            _dealerService = dealerService;
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

        public IActionResult CustomerDetail(int id)
        {
            List<SelectListItem> customerList = (from x in c.Customers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.Id.ToString()
                                             }).ToList();

            ViewBag.Customer = customerList;

            ViewBag.Dealers = _dealerService.GetAll().Where(x=>x.CustomerId == id);

            var customer = _customerService.GetById(id);
            return View(customer);
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
        public async Task<IActionResult> AddCustomer(Customer customer)
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
            if (customer.File != null && customer.File.Count() > 0)
            {
                foreach (var item in customer.File)
                {
                    var extend = Path.GetExtension(item.FileName);
                    var randomName = $"{Guid.NewGuid()}{extend}";
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\CustomerFiles", randomName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }

                    CustomerFile customerFile = new CustomerFile();
                    customerFile.FileUrl = randomName;
                    customerFile.CustomerId = customer.Id;
                    c.CustomerFiles.Add(customerFile);
                    c.SaveChanges();
                }
            }

            
            return RedirectToAction("Index","Customer");
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {

            List<SelectListItem> cityList = (from x in c.Cities.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.Id.ToString()
                                             }).ToList();

            ViewBag.City = cityList;


            

            var customer = _customerService.GetById(id);

            List<SelectListItem> townList = (from x in c.Towns.Where(x=>x.CityId == customer.CityId).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.Id.ToString()
                                             }).ToList();

            ViewBag.Town = townList;
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
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

            _customerService.Update(customer);
            

            return RedirectToAction("Index", "Customer");
        }


        public IActionResult DeleteCustomer(int id)
        {
            var customer = _customerService.GetById(id);
            _customerService.Delete(customer);
            return RedirectToAction("Index", "Customer");
        }
    }
}
