using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using buyforus.Models;
using buyforus.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace buyforus.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly ApplicationContext applicationContext;
        

        public CampaignService(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task<Campaign> FindCampaignByIdAsync(long campaignId)
        {
            var campaign = await applicationContext.Campaigns.SingleOrDefaultAsync(x => x.CampaignId == campaignId);
            return campaign;
        }

        public async Task<List<Campaign>> ListAllCampaignAsync()
        {
            var campaigns = await applicationContext.Campaigns.ToListAsync();
            return campaigns;
        }

        public async Task DecrementProductAmount(ApiViewModel model)
        {
            var campaign = await FindCampaignById(model.CampaignId);
            // elő kellene szerezni az adott productot a neve alapján model.ProductName
            // a product amountból kivonni a model.Amount
        }
        public async Task<Campaign> FindCampaignById(long campaignId)
        {
            var campaign = await applicationContext.Campaigns.FirstOrDefaultAsync(a => a.CampaignId == campaignId);
            return campaign;
        }
    }
}