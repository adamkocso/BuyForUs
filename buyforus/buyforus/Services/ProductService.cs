using System.Linq;
using System.Threading.Tasks;
using buyforus.Models;
using buyforus.ViewModels;
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

        public async Task AddProductAsync(CampaignViewModel campaignViewModel)
        {
            var newProduct = new Product
            {
                ProductName = campaignViewModel.Product.ProductName,
                Price = campaignViewModel.Product.Price,
                Amount = campaignViewModel.Product.Amount,
                CampaignId = campaignViewModel.Campaign.CampaignId
            };
            await applicationContext.Products.AddAsync(newProduct);
            await applicationContext.SaveChangesAsync();
        }
    }
}