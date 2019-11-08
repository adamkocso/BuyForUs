using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using buyforus.Models;
using buyforus.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace buyforus.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext applicationContext;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IImageService imageService;

        public UserService(ApplicationContext applicationContext, SignInManager<User> signInManager, UserManager<User> userManager,
            IMapper mapper, IImageService imageService)
        {
            this.applicationContext = applicationContext;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.mapper = mapper;
            this.imageService = imageService;
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> RegisterAsync(DonaterViewModel model)
        {
            var donater = new User {UserName = model.Username, Email = model.Email};
            var result = await userManager.CreateAsync(donater, model.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(donater, "Donator");
                return result;
            }

            return result;
        }

        public async Task EditDonaterProfile(DonaterViewModel model, string userId)
        {
            var user = await applicationContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            user.UserName = model.Username;
            user.Email = model.Email;
            applicationContext.Users.Update(user);
            await applicationContext.SaveChangesAsync();
        }

        public async Task EditOrgProfile(OrganizationViewModel model, string userId)
        {
            var user = await applicationContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            var campaign = await applicationContext.Campaigns.FirstOrDefaultAsync(y => y.UserId == userId);
            mapper.Map(model, user);
            if (campaign != null)
            {
                campaign.Uri = user.Uri;
                applicationContext.Campaigns.Update(campaign);
            }
            applicationContext.Users.Update(user);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<IdentityResult> RegisterAsync(OrganizationViewModel model)
        {
            var organization = mapper.Map<OrganizationViewModel, User>(model);
            var result = await userManager.CreateAsync(organization, model.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(organization, "Organization");
            }

            return result;
        }

        public async Task<List<string>> LoginAsync(LoginViewModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                model.ErrorMessages.Add("User with the given Email does not exist");
                return model.ErrorMessages;
            }

            var result = await signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false,
                lockoutOnFailure: false);
            model.ErrorMessages = CheckLoginErrors(result, model.ErrorMessages);
            return model.ErrorMessages;
        }
        
        private List<string> CheckLoginErrors(SignInResult result, List<string> errors)
        {
            if (!result.Succeeded)
            {
                errors.Add("Invalid login attempt");
            }

            return errors;
        }

        public async Task SetIndexImageAsync(User user, string blobContainerName)
        {
            var pictures = await imageService.ListAsync(user.Id, blobContainerName);
            user.Uri = pictures[0].Path;
            applicationContext.Users.Update(user);
            await applicationContext.SaveChangesAsync();
        }

        public async Task AddToDonationAmountAsync(int price, string userId)
        {
            var user = await applicationContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            user.DonationAmount += price;
            applicationContext.Users.Update(user);
           await applicationContext.SaveChangesAsync();
        }
    }
}