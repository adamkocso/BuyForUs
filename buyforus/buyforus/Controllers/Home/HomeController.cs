using Microsoft.AspNetCore.Mvc;

namespace buyforus.Controllers.Home
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}