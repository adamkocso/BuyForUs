using System.Threading.Tasks;
using AutoMapper;
using buyforus.Services;
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
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly IImageService imageService;
        private readonly ICampaignService campaignService;

        public ProfileController(IUserService userService, IMapper mapper, UserManager<User> userManager,
            IImageService imageService, ICampaignService campaignService)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.userManager = userManager;
            this.imageService = imageService;
            this.campaignService = campaignService;
        }

        [HttpGet("/donaterprofile")]
        public async Task<IActionResult> DonaterProfile()
        {
            var currentDonater = await userManager.GetUserAsync(HttpContext.User);

            return View(new UserViewModel{ User = currentDonater });
        }

        [HttpGet("/orgprofile")]
        public async Task<IActionResult> OrgProfile()
        {
            var currentOrg = await userManager.GetUserAsync(HttpContext.User);
            var campaign = await campaignService.FindCampaignByUserId(currentOrg.Id);

            return View(new UserViewModel{User = currentOrg, Campaign = campaign });
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
                if (editUserProfile.File != null)
                {
                    var errors = imageService.Validate(editUserProfile.File, editUserProfile.ErrorMessages);
                    if (errors.Count != 0)
                    {
                        return View(editUserProfile);
                    }
                    await imageService.UploadAsync(editUserProfile.File, currentDonater.Id, "donater");
                    await userService.EditDonaterProfile(editUserProfile, currentDonater.Id);
                    await userService.SetIndexImageAsync(currentDonater, "donater");
                }
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
                if (editOrgProfile.File != null)
                {
                    var errors = imageService.Validate(editOrgProfile.File, editOrgProfile.ErrorMessages);
                    if (errors.Count != 0)
                    {
                        return View(editOrgProfile);
                    }
                    await imageService.UploadAsync(editOrgProfile.File, currentOrg.Id, "organization");
                    await userService.EditOrgProfile(editOrgProfile, currentOrg.Id);
                    await userService.SetIndexImageAsync(currentOrg, "organization");
                }
                return RedirectToAction(nameof(OrgProfile));
            }

            return View(editOrgProfile);
        }
    }
}