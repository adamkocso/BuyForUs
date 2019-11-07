using System.Threading.Tasks;
using buyforus.Controllers.Home;
using buyforus.Services;
using buyforus.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace buyforus.Controllers.User
{
    public class UserController : Controller
    {
        private readonly UserService userService;
        private readonly UserManager<Models.User> userManager;

        public UserController(UserService userService, UserManager<Models.User> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }

        [HttpGet("/DonaterReg")]
        public IActionResult DonaterRegistration()
        {
            return View();
        }

        [HttpGet("/OrganizationReg")]
        public IActionResult OrganizationRegistration()
        {
            return View();
        }
        
        [HttpPost("/DonaterReg")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DonaterRegistration(DonaterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await userService.RegisterAsync(model);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }
        
        
        
        
        
        

        [HttpGet("/login")]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            await userService.LogoutAsync();
            return View(new LoginViewModel());
        }

        [HttpPost("/login")]
        [ValidateAntiForgeryToken]
        public IActionResult Login(OrganizationViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                return RedirectToAction(nameof(UserController.LoginUsers), "User");
            }

            return View(model);
        }
        
        [HttpPost("/login")]
        [ValidateAntiForgeryToken]
        public  IActionResult Login(DonaterViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(UserController.LoginUsers), "User");
            }

            return View(model);
        }
        
        [HttpPost("/login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginUsers(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var errors = await userService.LoginAsync(model);
                if (errors.Count == 0)
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }

                model.ErrorMessages = errors;
                return View(model);
            }

            return View(model);
        }
        
        
//        [HttpGet("/Google-login")]
//        public IActionResult GoogleLogin()
//        {
//            var redirectUrl = "Google-response";
//            var properties = userService.ConfigureExternalAutheticationProp("Google", redirectUrl);
//
//            return new ChallengeResult("Google", properties);
//        }
//
//        [HttpGet("/Facebook-login")]
//        public IActionResult FacebookLogin()
//        {
//            var redirectUrl = "Google-response";
//            var properties = userService.ConfigureExternalAutheticationProp("Facebook", redirectUrl);
//
//            return new ChallengeResult("Facebook", properties);
//        }
//
//        [HttpGet("/Google-response")]
//        public async Task<IActionResult> GoogleResponse()
//        {
//            var info = await userService.GetExternalLoginInfoAsync();
//            if (info == null)
//            {
//                return RedirectToAction(nameof(Login));
//            }
//
//            var result = await userService.ExternalLoginSingnInAsync(info.LoginProvider, info.ProviderKey, false);
//            if (!result.Succeeded)
//            {
//                await userService.CreateAndLoginGoogleUserAsync(info);
//            }
//
//            return RedirectToAction(nameof(HomeController.Index), "Home");
//        }
    }
}