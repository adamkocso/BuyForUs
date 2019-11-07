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
        Task<Campaign> FindCampaignByIdAsync(long campaignId);
    }
}