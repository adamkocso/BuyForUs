using System.Threading.Tasks;
using buyforus.Models;
using buyforus.Services;
using buyforus.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;

namespace buyforus.Controllers.Product
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ApplicationContext applicationContext;
        private readonly UserManager<User> userManager;
        private readonly ICampaignService campaignService;

        public ProductController(IProductService productService, ApplicationContext applicationContext, 
            UserManager<User> userManager, ICampaignService campaignService)
        {
            this.productService = productService;
            this.applicationContext = applicationContext;
            this.userManager = userManager;
            this.campaignService = campaignService;
        }

        [HttpPost("/addproduct/{campaignId}")]
        public async Task<IActionResult> AddProduct(CampaignViewModel campaignViewModel, long campaignId)
        {
            if (ModelState.IsValid)
            {
                campaignViewModel.User = await userManager.GetUserAsync(HttpContext.User);
                campaignViewModel.Campaign = await campaignService.FindCampaignByIdAsync(campaignId);
                await productService.AddProductAsync(campaignViewModel);
                return RedirectToAction(nameof(CampaignController.CampaignInfo), "Campaign");
            }
            return RedirectToAction(nameof(CampaignController.CampaignInfo), "Campaign");
        }
    }
}