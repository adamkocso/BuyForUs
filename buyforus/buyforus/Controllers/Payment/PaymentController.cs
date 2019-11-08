using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace buyforus.Controllers.Payment
{
    public class PaymentController : Controller
    {
        [HttpPost("/payment")]
        public IActionResult Payment(int donationAmount)
        {
            ViewData["donationAmount"] = donationAmount;
            return View();
        }
        [HttpPost("/payed")]
        public IActionResult Payed()
        {
            return View();
        }
    }
}