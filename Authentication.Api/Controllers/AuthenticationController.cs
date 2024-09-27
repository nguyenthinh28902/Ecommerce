using Authentication.User.Service.Services.GoogleServices.Interfaces;
using Authentication.User.Service.Services.UserServices.Interfaces;
using Authentication.User.Service.ViewModels.SignInViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthenManagerService _authenManagerService;
       
        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthenManagerService authenManagerService)
        {
            _logger = logger;
            _authenManagerService = authenManagerService;
        }

        [Route("v1/sign-in")]
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] SignInViewModel signInViewModel)
        {
            var confirmedEmail = Url.ActionLink("ConfirmedEmail", "Authentication") ?? string.Empty;
            var userSignIn = await _authenManagerService.SignInAsync(signInViewModel, confirmedEmail);
            return Ok(userSignIn);
        }

        [Route("v1/confirm-email")]
        [HttpPost]
        public async Task<IActionResult> ConfirmedEmail([FromForm] string userId, [FromForm] string code)
        {
            var userSignIn = await _authenManagerService.ConfirmEmailAsync(userId, code);
            return Ok(userSignIn);
        }

        [AllowAnonymous]
        [Route("v1/sigin-google")]
        [HttpGet]
        public async Task<IActionResult> SiginGoogle(string returnUrl = "/loginview")
        {
            var userSignIn = await _authenManagerService.SignInGoogle();
            if (userSignIn.IsSucceeded)
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true, // Ngăn không cho truy cập cookie từ JavaScript
                    Secure = true, // Chỉ gửi cookie qua HTTPS
                    SameSite = SameSiteMode.Strict, // Ngăn chặn CSRF
                    Expires = DateTime.UtcNow.AddHours(5) // Thời gian tồn tại của cookie
                };
                Response.Cookies.Append("Authentication", userSignIn.Token, cookieOptions);
            }
            return Redirect(returnUrl);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Demo()
        {

            return Ok("Demo");
        }
    }
}
