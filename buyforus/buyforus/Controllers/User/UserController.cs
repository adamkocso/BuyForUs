using Microsoft.AspNetCore.Mvc;

namespace buyforus.Controllers.User
{
    public class UserController : Controller
    {
        [HttpGet("/DonaterReg")]
        public IActionResult DonaterRegistration()
        {
            return null;
        }
        
        [HttpGet("/OrganizationReg")]
        public IActionResult OrganizationRegistration()
        {
            return null;
        }
    }
}