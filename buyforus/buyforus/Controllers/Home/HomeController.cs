using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using buyforus.Services;
using Microsoft.AspNetCore.Mvc;

namespace buyforus.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly ICampaignService campaignService;

        public HomeController(ICampaignService campaignService)
        {
            this.campaignService = campaignService;
        }

        [HttpGet("/")]
        public async Task<IActionResult> Index()
        {
           var campaigns = await campaignService.ListAllCampaignAsync();
            return View(campaigns);
        }
    }
}