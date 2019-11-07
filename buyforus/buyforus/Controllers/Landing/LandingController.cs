using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace buyforus.Controllers.Landing
{
    public class LandingController : Controller
    {
        [HttpGet("/")]
        public IActionResult LandingPage()
        {
            return View();
        }
    }
}