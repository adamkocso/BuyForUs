using System.Collections.Generic;
using System.Threading.Tasks;
using buyforus.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace buyforus.Services
{
    public interface IUserService
    {
        Task LogoutAsync();
        Task<List<string>> LoginAsync(LoginViewModel model);
        Task<IdentityResult> RegisterAsync(OrganizationViewModel model);
        Task<IdentityResult> RegisterAsync(DonaterViewModel model);
        Task WithdrawMoneyAsync(ApiViewModel model);
        Task EditDonaterProfile(DonaterViewModel model, string userId);
        Task EditOrgProfile(OrganizationViewModel model, string userId);
    }
}