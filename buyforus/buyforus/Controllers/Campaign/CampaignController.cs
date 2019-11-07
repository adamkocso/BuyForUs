using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buyforus.Controllers.Campaign
{
    public class CampaignController:Controller
    {
        [HttpGet("/campaignInfo")]
        public IActionResult CampaignInfo()
        {
            return View();
        }
    }
}
