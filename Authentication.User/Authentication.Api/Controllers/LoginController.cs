using Authentication.User.Service.Services.UserServices.Interfaces;
using Authentication.User.Service.ViewModels.SignInViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Controllers
{
    public class LoginController : Controller
    {

        private readonly IAuthenManagerService _authenManagerService;
        public LoginController(IAuthenManagerService authenManagerService) {
            _authenManagerService = authenManagerService;
        }

        [HttpGet("loginview")]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string returnUrl)
        {
            var model = new SignInViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = await _authenManagerService.GetExternalLoginsAsync()
            };

            return View(model);
        }
        [AllowAnonymous]
        [HttpPost("loginview")]
        public async Task<IActionResult> ExternalLogin(string provider, string returnUrl)
        {
            if(string.IsNullOrEmpty(returnUrl)) {              
                returnUrl = Url.ActionLink("SiginGoogle", "Authentication") ?? string.Empty;
            }
            var properties =
                 await _authenManagerService.ExternalLoginAsync(provider, returnUrl);

            return new ChallengeResult(provider, properties);
        }

        //[AllowAnonymous]
        //[Route("signin-google")]
        //[HttpGet]
        //public async Task<IActionResult> SiginGoogle([FromQuery] GoogleLoginModel model)
        //{
        //    // Exchange the authorization code for a token
        //    if (model == null || string.IsNullOrEmpty(model.Code))
        //    {
        //        return BadRequest("Invalid Google login request.");
        //    }
        //    var re = Request;
        //    var userSignIn = await _authenManagerService.SignInGoogle(model);

        //    return Ok(userSignIn);
        //}
    }
}
