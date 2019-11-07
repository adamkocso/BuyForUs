using buyforus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buyforus.Services
{
    public interface ICampaignService
    {
        Task<List<Campaign>> ListAllCampaignAsync();
        Campaign findCampaignById(long campaignId);
    }
}
