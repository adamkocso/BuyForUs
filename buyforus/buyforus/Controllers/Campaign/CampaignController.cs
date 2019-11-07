using buyforus.Controllers.Home;
using buyforus.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buyforus.Controllers.Campaign
{
    public class CampaignController : Controller
    {
        private readonly ICampaignService campaignService;

        public CampaignController(ICampaignService campaignService)
        {
            this.campaignService = campaignService;
        }

        [HttpGet("/campaigninfo/{campaignID}")]
        public async Task<IActionResult> CampaignInfo(long campaignId)
        {
            if (campaignId != 0)
            {
                var CampaignViewModel =await campaignService.FindCampaignByIdAsync(campaignId);
                return View(CampaignViewModel);
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
