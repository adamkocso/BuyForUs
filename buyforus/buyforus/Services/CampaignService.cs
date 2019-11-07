using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using buyforus.Models;
using buyforus.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace buyforus.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IMapper mapper;

        public CampaignService(ApplicationContext applicationContext, IMapper mapper)
        {
            this.applicationContext = applicationContext;
            this.mapper = mapper;
        }

        public async Task<List<Campaign>> ListAllCampaignAsync()
        {
            var campaigns = await applicationContext.Campaigns.ToListAsync();
            return campaigns;
        }

        public async Task AddCampaignAsync(AddCampaignViewModel addCampaignViewModel, User user)
        {
            var campaign = mapper.Map<AddCampaignViewModel, Campaign>(addCampaignViewModel);
            campaign.UserId = user.Id;
            campaign.ExpiryDate = SetExpiryDate();
            await applicationContext.Campaigns.AddAsync(campaign);
            await applicationContext.SaveChangesAsync();
        }

        public DateTime SetExpiryDate()
        {
            var expiryDate = DateTime.Today.AddDays(30);
            return expiryDate;
        }
    }
}