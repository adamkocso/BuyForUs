﻿using buyforus.Controllers.Home;
using buyforus.Models;
using buyforus.Services;
using buyforus.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using buyforus.Services;

namespace buyforus.Controllers
{
    [Authorize]
    public class CampaignController : Controller
    {
        private readonly ICampaignService campaignService;
        private readonly UserManager<User> userManager;
        private readonly IProductService productService;

        public CampaignController(ICampaignService campaignService, UserManager<User> userManager, IProductService productService)
        {
            this.campaignService = campaignService;
            this.userManager = userManager;
            this.productService = productService;
        }

        [HttpGet("/campaigninfo/{campaignId}")]
        public async Task<IActionResult> CampaignInfo(long campaignId)
        {
            if (campaignId != 0)
            {
                var currentUser = await userManager.GetUserAsync(HttpContext.User);
                var campaign = await campaignService.FindCampaignByIdAsync(campaignId);
                var product = await productService.FindProductByCampaignIdAsync(campaignId);
                return View(new CampaignViewModel
                    { Campaign = campaign, User = currentUser, Products = product});
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
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
                var campaignId = await campaignService.AddCampaignAsync(addCampaignViewModel, currentUser);
                return RedirectToAction(nameof(CampaignController.CampaignInfo), "Campaign", new {campaignId});
            }

            return View(addCampaignViewModel);
        }
    }
}