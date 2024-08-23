using Authentication.User.Service.Services.UserServices.Interfaces;
using Authentication.User.Service.ViewModels.SignInViewModels;
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

        [Route("v1/admin/sign-in")]
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] SignInViewModel signInViewModel)
        {
            var confirmedEmail = Url.ActionLink("ConfirmedEmail", "Authentication") ?? string.Empty;
            var userSignIn = await _authenManagerService.SignInAsync(signInViewModel, confirmedEmail);
            return Ok(userSignIn);
        }

        [Route("v1/admin/confirm-email")]
        [HttpPost]
        public async Task<IActionResult> ConfirmedEmail([FromForm] string userId, [FromForm] string code)
        {
            var userSignIn = await _authenManagerService.ConfirmEmailAsync(userId, code);
            return Ok(userSignIn);
        }

        [Route("v1/Demo")]
        [HttpPost]
        public async Task<IActionResult> Authentication()
        {
            return Ok(true);
        }
    }
}
