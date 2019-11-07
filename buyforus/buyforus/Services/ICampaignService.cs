using buyforus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using buyforus.ViewModels;

namespace buyforus.Services
{
    public interface ICampaignService
    {
        Task<List<Campaign>> ListAllCampaignAsync();
        Task AddCampaignAsync(AddCampaignViewModel addCampaignViewModel, User user);
        DateTime SetExpiryDate();
    }
}
