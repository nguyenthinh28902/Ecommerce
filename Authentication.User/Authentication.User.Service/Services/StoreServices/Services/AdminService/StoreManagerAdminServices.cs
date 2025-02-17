using Authentication.User.DataAccess.Entities;
using Authentication.User.DataAccess.Service.StoreServices.Interfaces;
using Authentication.User.DataAccess.Service.StoreServices.Services;
using Authentication.User.Service.Helpers.Exceptions;
using Authentication.User.Service.Services.ApplicationLogService.Interfaces;
using Authentication.User.Service.Services.StoreServices.Interfaces.AdminService;
using Authentication.User.Service.Services.UserServices.Interfaces;
using Authentication.User.Service.ViewModels;
using Authentication.User.Service.ViewModels.Enum;
using AutoMapper;
using FeatureLibrary.LogLibrary;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.Service.Services.StoreServices.Services.AdminService
{
    public class StoreManagerAdminServices : IStoreManagerAdminServices
    {
        private readonly IMapper _mapper;
        public readonly IDALStoreManager _dALStoreManager;
        public readonly IUserInformationService _userInformationService;
        private readonly IApplicationLogManagerService _applicationLogManagerService;
        private readonly ILogger<StoreManagerAdminServices> _logger;
        public StoreManagerAdminServices(IMapper Mapper, IDALStoreManager DALStoreManager, IUserInformationService userInformationService, 
            IApplicationLogManagerService applicationLogManagerService,
            ILogger<StoreManagerAdminServices> logger)
        {
            _mapper = Mapper;
            _dALStoreManager = DALStoreManager;
            _userInformationService = userInformationService;
            _applicationLogManagerService = applicationLogManagerService;
            _logger = logger;
        }

        public async Task<ResultModel<Guid>> StoreApproveAsync(Guid storeId)
        {
            var result = new ResultModel<Guid>();

            var storeApprove = await _dALStoreManager.GetStoreByIdAsync(storeId);
            if (storeApprove == null) throw new NotFoundException(storeId.ToString());

            storeApprove.ApproveAt = DateTimeOffset.UtcNow;
            storeApprove.IsApprove = true;
            var resultUpdate = await _dALStoreManager.UpdateAsync(storeApprove);
            result.Message = resultUpdate ? Message.MessageApproveSuccess : Message.MessageApproveFailure;
            result.Value = storeId;
            result.IsSuccess = resultUpdate;

            try
            {
                await _applicationLogManagerService.CreateAsync(nameof(StoreApproveAsync), storeApprove.GetType().ToString(), storeApprove.Id.ToString(), result.IsSuccess);
            }
            catch (Exception ex)
            {

                var informationLoger = new InformationLoger(nameof(StoreApproveAsync), ex, nameof(IApplicationLogManagerService));
                _logger.LogError(informationLoger.GetMessage());
            }


            return result;
        }

    }
}
