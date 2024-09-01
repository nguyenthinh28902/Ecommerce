using Authentication.Admin.Service.Services.UserServices.Interfaces;
using Authentication.Admin.Service.ViewModels.SignInViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Authentication.Admin.Api.Controllers
{
    [Route("api/[controller]/v1/admin")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthenManagerService _authenManagerService;
        private readonly IConfiguration _configuration;
        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthenManagerService authenManagerService, IConfiguration configuration)
        {
            _logger = logger;
            _authenManagerService = authenManagerService;
            _configuration = configuration;
        }

        [Route("sign-in")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] SignInViewModel signInViewModel)
        {
            _logger.LogInformation(JsonConvert.SerializeObject(signInViewModel));
            var confirmedEmailAction = Url.Action("ConfirmedEmail", "Authentication") ?? string.Empty;
            var apiGateway = _configuration["ApiGateway"];
            var confirmedEmailUrl = new Uri(new Uri(apiGateway), confirmedEmailAction).ToString();
            var userSignIn = await _authenManagerService.SignInAsync(signInViewModel, confirmedEmailUrl);

            return Ok(userSignIn);
        }

        [Route("confirm-email")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmedEmail([FromForm] string userId, [FromForm] string code)
        {
            var userSignIn = await _authenManagerService.ConfirmEmailAsync(userId, code);
            return Ok(userSignIn);
        }

        [Route("Demo")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Authentication() {
            return Ok(true);
        }
    }
}
