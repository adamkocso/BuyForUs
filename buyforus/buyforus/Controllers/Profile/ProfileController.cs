using buyforus.ViewModels;
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

        [HttpGet("/edituserprofile")]
        public IActionResult EditUserProfile()
        {
            return null;
        }

        [HttpPost("/edituserprofile")]
        public IActionResult EditUserProfile(UserProfileViewModel editUserProfile)
        {
            return null;
        }
        
        [HttpGet("/editorgprofile")]
        public IActionResult EditOrgProfile()
        {
            return null;
        }

        [HttpPost("/editorgprofile")]
        public IActionResult EditOrgProfile(OrgProfileViewModel editOrgProfile)
        {
            return null;
        }
    }
}