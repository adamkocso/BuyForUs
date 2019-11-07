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

        [HttpGet("/campaignInfo/{campaignID}")]
        public IActionResult CampaignInfo(long campaignID)
        {
            if (campaignID != 0)
            {
                var CampaignViewModel = campaignService.findCampaignById();
                return View();
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
