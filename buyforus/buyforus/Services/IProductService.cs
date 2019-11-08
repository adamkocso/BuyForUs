using System.Threading.Tasks;
using buyforus.ViewModels;

namespace buyforus.Services
{
    public interface IProductService
    {
        Task AddProductAsync(CampaignViewModel campaignViewModel);
    }
}