using Authentication.User.DataAccess.Entities;
using Authentication.User.DataAccess.Service.StoreServices.Interfaces;
using Authentication.User.Service.Helpers.Exceptions;
using Authentication.User.Service.Services.StoreServices.Interfaces;
using Authentication.User.Service.Services.UserServices.Interfaces;
using Authentication.User.Service.ViewModels;
using Authentication.User.Service.ViewModels.Enum;
using Authentication.User.Service.ViewModels.StoreViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.Service.Services.StoreServices.Services
{
    public class StoreManagerServices : IStoreManagerServices
    {
        private readonly IMapper _mapper;
        public readonly IDALStoreManager _dALStoreManager;
        public readonly IUserInformationService _userInformationService;
        public StoreManagerServices(IMapper Mapper, IDALStoreManager DALStoreManager, IUserInformationService userInformationService)
        {
            _mapper = Mapper;
            _dALStoreManager = DALStoreManager;
            _userInformationService = userInformationService;
        }

        public async Task<ResultModel<Guid>> Register(RegisterStoreViewModel registerStoreViewModel)
        {
            var resultModel = new ResultModel<Guid>();
            var userId = _userInformationService.GetUserId();
            if (string.IsNullOrEmpty(userId)) throw new NotFoundException(Message.MessageNotFoundUserLogin);
            var storeNew = _mapper.Map<Store>(registerStoreViewModel);
            storeNew.StoreOwer = userId;
            if (string.IsNullOrEmpty(storeNew.PhoneNumber) || string.IsNullOrEmpty(storeNew.Email))
            {
                var message = string.IsNullOrEmpty(storeNew.PhoneNumber) ? GT<RegisterStoreViewModel>.Display(x => x.PhoneNumber)
                    : string.IsNullOrEmpty(storeNew.Email) ? GT<RegisterStoreViewModel>.Display(x => x.Email) : string.Empty;
                message += string.IsNullOrEmpty(storeNew.Email) ?  " và " + GT<RegisterStoreViewModel>.Display(x => x.Email) : string.Empty;
               
                throw new BadRequestException(message + " không được bỏ trống");
            }
            var result = await _dALStoreManager.CreateAsync(storeNew);
            resultModel.Value = result?.Id ?? Guid.Empty;
            if (resultModel.Value != Guid.Empty)
            {
                resultModel.Message = Message.MessageCreateSuccess;
            }
            else
            {
                resultModel.Message = Message.MessageCreateFailure;
            }
            return resultModel;

        }
    }
}
