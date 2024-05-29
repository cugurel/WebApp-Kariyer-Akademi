using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class DealerController : Controller
    {
        IDealerService _dealerService;

        public DealerController(IDealerService dealerService)
        {
            _dealerService = dealerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDealer(Dealer dealer)
        {
            _dealerService.Add(dealer);
            return RedirectToAction("CustomerDetail", "Customer" + dealer.CustomerId);
        }
    }
}
