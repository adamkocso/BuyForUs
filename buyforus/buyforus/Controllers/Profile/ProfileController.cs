using Microsoft.AspNetCore.Mvc;

namespace buyforus.Controllers.Profile
{
    public class ProfileController : Controller
    {
        [HttpGet("/userprofile")]
        public IActionResult UserProfile()
        {
            return View();
        }

        [HttpGet("/orgprofile")]
        public IActionResult OrgProfile()
        {
            return View();
        }
    }
}