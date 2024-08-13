using Authentication.Service.Services.UserService.Service;
using Authentication.Service.ViewModel.SignInViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly AuthenManagerService _authenManagerService;
        public AuthenticationController(ILogger<AuthenticationController> logger, AuthenManagerService authenManagerService)
        {
            _logger = logger;
            _authenManagerService = authenManagerService;
        }

        [Route("v1/admin/sign-in")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] SignInViewModel signInViewModel)
        {
            var userSignIn = await _authenManagerService.SignInAsync(signInViewModel);
            return Ok(userSignIn);
        }

        [Route("v1/Demo")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Authentication()
        {
            return Ok(true);
        }
    }
}
