using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace buyforus.Controllers.Payment
{
    public class PaymentController : Controller
    {
        [HttpGet("/payment")]
        public IActionResult Payment()
        {
            return View();
        }
    }
}