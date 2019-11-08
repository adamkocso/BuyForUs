using buyforus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buyforus.Services
{
   public interface IProductService
    {
        Task<List<Product>> FindProductByCampaignIdAsync(long campaignId);
    }
}
