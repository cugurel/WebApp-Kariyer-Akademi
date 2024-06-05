using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Authorize]
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
            return RedirectToAction("CustomerDetail", "Customer", new { id = dealer.CustomerId });
        }
    }
}
