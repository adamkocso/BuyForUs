using System.Threading.Tasks;
using buyforus.Models;
using buyforus.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace buyforus.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<User> userManager;

        public ProfileController(UserManager<Models.User> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet("/donaterprofile")]
        public async Task<IActionResult> DonaterProfile()
        {
            var currentDonater = await userManager.GetUserAsync(HttpContext.User);
            return View(new UserViewModel{User = currentDonater});
        }

        [HttpGet("/orgprofile")]
        public async Task<IActionResult> OrgProfile()
        {
            var currentOrg = await userManager.GetUserAsync(HttpContext.User);
            return View(new UserViewModel{User = currentOrg});
        }

        [HttpGet("/editdonaterprofile")]
        public IActionResult EditDonaterProfile()
        {
            return null;
        }

        [HttpPost("/editdonaterprofile")]
        public IActionResult EditDonaterProfile(UserViewModel editUserProfile)
        {
            return null;
        }
        
        [HttpGet("/editorgprofile")]
        public IActionResult EditOrgProfile()
        {
            return null;
        }

        [HttpPost("/editorgprofile")]
        public IActionResult EditOrgProfile(UserViewModel editOrgProfile)
        {
            return null;
        }
    }
}