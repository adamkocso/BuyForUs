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

        public async Task<Campaign> FindCampaignByIdAsync(long campaignId)
        {
            var campaign = await applicationContext.Campaigns.Include(x => x.Products)
                .SingleOrDefaultAsync(x => x.CampaignId == campaignId);
            return campaign;
        }

        public async Task<List<Campaign>> ListAllCampaignAsync()
        {
            var campaigns = await applicationContext.Campaigns.ToListAsync();
            return campaigns;
        }

        public async Task<long> AddCampaignAsync(AddCampaignViewModel addCampaignViewModel, User user)
        {
            var campaign = new Campaign
            {
                Description = addCampaignViewModel.Description,
                Title = addCampaignViewModel.Title,
                UserId = user.Id,
                ExpiryDate = SetExpiryDate(),
                Uri = user.Uri
            };
            var result = await applicationContext.Campaigns.AddAsync(campaign);
            await applicationContext.SaveChangesAsync();
            return campaign.CampaignId;
        }

        public DateTime SetExpiryDate()
        {
            var expiryDate = DateTime.Today.AddDays(30);
            return expiryDate;
        }

        public Task<Campaign> FindCampaignByUserId(string id)
        {
            var campaign = applicationContext.Campaigns.SingleOrDefaultAsync(x => x.UserId == id);
            return campaign;
        }
    }
}