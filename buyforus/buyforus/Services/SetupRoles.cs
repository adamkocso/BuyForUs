using buyforus.Models;
using Microsoft.AspNetCore.Identity;

namespace buyforus.Services
{
    public class SetupRoles
    {
        public static void CreateUsersWithRoles(UserManager<User> userManager)
        {
            if (userManager.FindByEmailAsync("admin@gmail.com").Result == null)
            {
                User user = new User
                {
                    UserName = "Admin",
                    Email = "admin@gmail.com",
                };

                IdentityResult check = userManager.CreateAsync(user, "Password1234..").Result;

                if (check.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            if (userManager.FindByEmailAsync("organization@gmail.com").Result == null)
            {
                User user = new User
                {
                    UserName = "Organization",
                    Email = "organization@gmail.com",
                };

                IdentityResult check = userManager.CreateAsync(user, "Password1234..").Result;

                if (check.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Organization").Wait();
                }
            }

            if (userManager.FindByEmailAsync("user@gmail.com").Result == null)
            {
                User user = new User
                {
                    UserName = "User",
                    Email = "user@gmail.com",
                };

                IdentityResult check = userManager.CreateAsync(user, "Password1234..").Result;

                if (check.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }
        }
    }
}
