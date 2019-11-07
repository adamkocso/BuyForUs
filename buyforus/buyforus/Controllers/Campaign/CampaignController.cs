using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using buyforus.Services;
using buyforus.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace buyforus.Controllers.Campaign
{
    public class CampaignController : Controller
    {
        private readonly UserManager<Models.User> userManager;
        private readonly ICampaignService campaignService;

        public CampaignController(UserManager<Models.User> userManager, ICampaignService campaignService)
        {
            this.userManager = userManager;
            this.campaignService = campaignService;
        }

        [HttpGet("/campaignInfo")]
        public IActionResult CampaignInfo()
        {
            return View();
        }

        [HttpGet("/addcampaign")]
        public IActionResult AddCampaign()
        {
            return View();
        }

        [HttpPost("/addcampaign")]
        public async Task<IActionResult> AddCampaign(AddCampaignViewModel addCampaignViewModel)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await userManager.GetUserAsync(HttpContext.User);
                campaignService.AddCampaignAsync(addCampaignViewModel, currentUser);
                RedirectToAction(nameof(CampaignController.CampaignInfo), "Campaign");
            }

            return View(addCampaignViewModel);
        }
    }
}
