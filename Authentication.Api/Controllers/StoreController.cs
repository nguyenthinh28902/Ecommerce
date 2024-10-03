using Authentication.User.Service.Services.StoreServices.Interfaces;
using Authentication.User.Service.Services.StoreServices.Interfaces.AdminService;
using Authentication.User.Service.ViewModels.Enum;
using Authentication.User.Service.ViewModels.StoreViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly ILogger<StoreController> _logger;
        private readonly IStoreManagerServices _storeManagerServices;
        private readonly IStoreManagerAdminServices _storeManagerAdminServices;

        public StoreController(ILogger<StoreController> logger, IStoreManagerServices storeManagerServices,
            IStoreManagerAdminServices storeManagerAdminServices)
        {
            _logger = logger;
            _storeManagerServices = storeManagerServices;
            _storeManagerAdminServices = storeManagerAdminServices;
        }

        [Authorize]
        [HttpPost]
        [Route("v1/register-store")]
        public async Task<IActionResult> RegisterStore([FromBody]RegisterStoreViewModel registerStoreViewModel)
        {
            var result = await _storeManagerServices.Register(registerStoreViewModel);
            return Ok(result);
        }

        [Authorize(AuthenticationSchemes = AuthenticationApp.Admin)]
        [HttpPut]
        [Route("v1/store-approve/{Id}")]
        public async Task<IActionResult> StoreApprove(Guid Id)
        {
            var result = await _storeManagerAdminServices.StoreApproveAsync(Id);
            return Ok(result);
        }
    }
}
