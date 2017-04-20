using System.Threading.Tasks;
using LoanApplication.Services;
using LoanApplication.Models;
using LoanApplication.Models.ManageAccounts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace LoanApplication.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private IEmailSender _sendEmail;
        private SignInManager<LoanApplicationUser> _signInManager;
        private ISmsSender _smsSender;
        private UserManager<LoanApplicationUser> _userManager;
        //private ILogger _logger;

        public CustomersController(
            UserManager<LoanApplicationUser>userManager,
            SignInManager<LoanApplicationUser>signInManager,
            IEmailSender sendEmail,
            ISmsSender smsSender
             //ILogger logger
            )
        {

            _userManager = userManager;
            _signInManager = signInManager;

           // _logger = logger;
            _sendEmail = sendEmail;
            _smsSender = smsSender;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public  IActionResult Register()
        {

        
            return View("Register");
        

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task <IActionResult> Register(Customers model)
        {

            if (ModelState.IsValid)
            {                                                      
                var user = new LoanApplicationUser
                { UserName = model.UserName, Email = model.Email };

                var result = await _userManager.CreateAsync(user, model.Password);
                 var 

                if (result.Succeeded)
                {

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    var callbackUrl = Url.Action("ConfirmEmail", "Customers", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                    await _sendEmail.SendEmailAsync(model.Email, "Confirm your account",
                        $"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a>");

                    await _signInManager.SignInAsync(user, false);

                    return RedirectToAction("Index","LoanList");


                }
                AddErrors(result);

            }

            return View();
        }

           [HttpGet]
           [AllowAnonymous]
           
        public IActionResult Login()
        {
            return View("Login");
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {

            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                   // _logger.LogInformation(1, "User logged in.");

                    return RedirectToAction("Index", "LoanList");
                }
                if (result.IsLockedOut)
                {
                    //_logger.LogWarning(3, "User account locked out.");
                    return View("Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }

            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("Error");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
           // ILogger.LogInformation(4, "User logged out.");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

           
        }

    }
}                      