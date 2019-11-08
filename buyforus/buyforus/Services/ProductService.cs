using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using buyforus.Models;
using Microsoft.EntityFrameworkCore;

namespace buyforus.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationContext applicationContext;

        public ProductService(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task<List<Product>> FindProductByCampaignIdAsync(long campaignId)
        {
            var prod = await applicationContext.Products.Where(p => p.CampaignId == campaignId).ToListAsync(); ;
            return prod;
        }
    }
}
