using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using buyforus.Models;
using buyforus.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace buyforus.Services
{
    public class UserService : IUserService
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public UserService(SignInManager<User> signInManager, UserManager<User> userManager, IMapper mapper)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.mapper = mapper;
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
                await userManager.AddToRoleAsync(donater, "DONATOR");
                return result;
            }

            return result;
        }

        public void WithdrawMoney(ApiViewModel model)
        {
            throw new System.NotImplementedException();
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
    }
}