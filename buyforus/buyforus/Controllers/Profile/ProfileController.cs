using System.Threading.Tasks;
using buyforus.ViewModels;
using buyforus.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace buyforus.Controllers.Profile
{
    public class ProfileController : Controller
    {
        private readonly UserManager<Donater> donater;

        public ProfileController(UserManager<Donater> donater)
        {
            this.donater = donater;
        }

        [HttpGet("/donaterprofile")]
        public async Task<IActionResult> DonaterProfile()
        {
            var currentDonater = await donater.GetUserAsync(HttpContext.User);
            return View(new DonaterViewModel{Donater = currentDonater});
        }

        [HttpGet("/orgprofile")]
        public IActionResult OrgProfile()
        {
            return View();
        }

        [HttpGet("/editdonaterprofile")]
        public IActionResult EditDonaterProfile()
        {
            return null;
        }

        [HttpPost("/editdonaterprofile")]
        public IActionResult EditDonaterProfile(DonaterViewModel editUserProfile)
        {
            return null;
        }
        
        [HttpGet("/editorgprofile")]
        public IActionResult EditOrgProfile()
        {
            return null;
        }

        [HttpPost("/editorgprofile")]
        public IActionResult EditOrgProfile(OrganizationViewModel editOrgProfile)
        {
            return null;
        }
    }
}