using KingPim.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KingPim.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            // Checks if the user is authenticated and sends him/her to /Account:
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                return View();
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            // Checks if the username and password is correct:
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(vm.UserName);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user, vm.Password, false, false)).Succeeded)
                    {
                        return RedirectToAction("Index", "Account");
                    }
                }
            }
            return View("Index", vm);
        }
         
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgottenPassword(LoginViewModel vm)
        {

            var user = await _userManager.FindByNameAsync(vm.UserName);
            var confCode = await _userManager.GeneratePasswordResetTokenAsync(user);
            var link = Url.Action("ResetPassword", "Home", new { userId = user.Id, code = confCode },
                protocol: Request.Scheme);         

            // The new SendGridClient with the API-key:
            var client = new SendGridClient("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");
            
            // The message from SendGrid:
            var msg = new SendGridMessage
            {
                From = new EmailAddress(vm.UserName, "Password Reset")
            };
            // The reciever of the mail:
            msg.AddTo(vm.UserName);
            // The template id the email should use from SendGrid:
            msg.TemplateId = "6a88245c-ff27-427c-817e-556d50213a82";

            // Set the substitution tag value. This will create a link to reset password.
            msg.AddSubstitution("substitutionLink", link);
            // Send the email async and get the response from API.
            var response = client.SendEmailAsync(msg).Result;

            return RedirectToAction(nameof(Index));
        }        

        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var usersName = user.UserName;
            var model = new LoginViewModel
            {
                UserName = usersName,
                Code = code
            };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(vm.UserName);
                var result = await _userManager.ResetPasswordAsync(user, vm.Code, vm.Password);
                var success = result.Succeeded; 
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }
    }
}
