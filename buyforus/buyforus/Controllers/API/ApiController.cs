using System.Threading.Tasks;
using buyforus.Services;
using buyforus.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace buyforus.Controllers.API
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ICampaignService campaignService;
        private readonly IUserService userService;

        public ApiController(ICampaignService campaignService, IUserService userService)
        {
            this.campaignService = campaignService;
            this.userService = userService;
        }
        
        [HttpPut("api/donation")]
        public async Task<ActionResult> Donation([FromBody] ApiViewModel model)
        {
            campaignService.DecrementProductAmount(model);
            userService.WithdrawMoney(model);
            
            return new OkObjectResult($"Your donation has been placed! Thank you!");
        }
    }
}