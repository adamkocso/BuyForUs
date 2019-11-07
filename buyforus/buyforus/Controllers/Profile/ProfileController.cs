using System.Threading.Tasks;
using AutoMapper;
using buyforus.Services;
using buyforus.Models;
using buyforus.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace buyforus.Controllers
{
    public class ProfileController : Controller
    {

        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public ProfileController(IUserService userService, IMapper mapper, UserManager<User> userManager)
        {
            this.userService = userService;
            this.mapper = mapper;
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
        public async Task<IActionResult> EditDonaterProfile()
        {
            var currentDonater = await userManager.GetUserAsync(HttpContext.User);
            return View(new DonaterViewModel()
            {
                Username = currentDonater.UserName,
                Email = currentDonater.Email
            });
        }

        [HttpPost("/editdonaterprofile")]
        public async Task<IActionResult> EditDonaterProfile(DonaterViewModel editUserProfile)
        {
            var currentDonater = await userManager.GetUserAsync(HttpContext.User);
            ModelState.Remove("Password");
            if(ModelState.IsValid)
            {
                await userService.EditDonaterProfile(editUserProfile, currentDonater.Id);
                return RedirectToAction(nameof(DonaterProfile));
            }
            
            return View(editUserProfile);
        }
        
        [HttpGet("/editorgprofile")]
        public async Task<IActionResult> EditOrgProfile()
        {
            var currentOrg = await userManager.GetUserAsync(HttpContext.User);
            var organizationViewModel = mapper.Map<User, OrganizationViewModel>(currentOrg);
            return View(organizationViewModel);
        }

        [HttpPost("/editorgprofile")]
        public async Task<IActionResult> EditOrgProfile(OrganizationViewModel editOrgProfile)
        {
            var currentOrg = await userManager.GetUserAsync(HttpContext.User);
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
                await userService.EditOrgProfile(editOrgProfile, currentOrg.Id);
                return RedirectToAction(nameof(OrgProfile));
            }

            return View(editOrgProfile);
        }
    }
}