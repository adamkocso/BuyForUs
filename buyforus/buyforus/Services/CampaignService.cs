using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using buyforus.Models;

namespace buyforus.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly ApplicationContext applicationContext;

        public CampaignService(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public List<Campaign> ListAllCampaign()
        {
            var campaigns = applicationContext.Campaigns.ToList();
            return campaigns;
        }
    }
}
