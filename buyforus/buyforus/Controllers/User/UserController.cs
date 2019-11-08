using System.Threading.Tasks;
using buyforus.Controllers.Home;
using buyforus.Models;
using buyforus.Services;
using buyforus.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace buyforus.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;

        public UserController(IUserService userService, UserManager<Models.User> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }
        
        [HttpGet("/OrganizationReg")]
        public IActionResult OrganizationRegistration()
        {
            return View();
        }
        
        [HttpPost("/OrganizationReg")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrganizationRegistration(OrganizationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await userService.RegisterAsync(model);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "User");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }
        
        [HttpGet("/DonaterReg")]
        public IActionResult DonaterRegistration()
        {
            return View();
        }
        
        [HttpPost("/DonaterReg")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DonaterRegistration(DonaterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await userService.RegisterAsync(model);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "User");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }
        
        [HttpGet("/account/login")]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            await userService.LogoutAsync();
            return View(new LoginViewModel());
        }

        [HttpPost("/account/login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var errors = await userService.LoginAsync(model);
                if (errors.Count == 0)
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }

                model.ErrorMessages = errors;
                return View(model);
            }

            return View(model);
        }
        [HttpGet("/logout")]
        public async Task<IActionResult> Logout()
        {
            await userService.LogoutAsync();
            return RedirectToAction(nameof(Landing.LandingController.LandingPage),"Landing");
        }
        [HttpPost("/addAmountToDonationAmount")]
        public async Task<IActionResult> AddToDonationAmount(int price, long campaignId)
        {
            var currentUser = await userManager.GetUserAsync(HttpContext.User);
           await userService.AddToDonationAmountAsync(price, currentUser.Id);

           return RedirectToAction(nameof(CampaignController.CampaignInfo), "Campaign", new {campaignId });
        }
    }
}