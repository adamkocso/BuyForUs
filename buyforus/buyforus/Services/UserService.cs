using System.Threading.Tasks;
using buyforus.Models;
using Microsoft.AspNetCore.Identity;

namespace buyforus.Services
{
    public class UserService : IUserService
    {
        private readonly SignInManager<User> signInManager;
        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}