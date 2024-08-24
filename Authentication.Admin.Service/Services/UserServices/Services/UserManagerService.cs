using Authentication.Admin.DataAccess.Entities;
using Authentication.Admin.DataAccess.Service.UserServices.Interfaces;
using Authentication.Admin.Service.Services.UserServices.Interfaces;
using Authentication.Admin.Service.ViewModels.DefaultModels;
using Authentication.Admin.Service.ViewModels.UserViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Admin.Service.Services.UserServices.Services
{
    public class UserManagerService : IUserManagerService
    {
        private readonly IDALUserManagerService _dALuserManagerService;
        private readonly IMapper _mapper;
        public UserManagerService(IDALUserManagerService dALuserManagerService, IMapper mapper)
        {
            _dALuserManagerService = dALuserManagerService;
            _mapper = mapper;
        }

        public async Task<ResultModel<string>> CreatedUserAsync(RegisterUserViewModel registerUserViewModel)
        {
            var user = _mapper.Map<ApplicationUser>(registerUserViewModel);
            var resultModel = new ResultModel<string>();
            var checkUser = await _dALuserManagerService
                .FirstOrDefaultAsync(x => x.Id == user.Id 
                || x.UserName == user.UserName 
                || (x.Email != null && x.Email.ToLower() == user.Email.ToLower())
                || (x.PhoneNumber != null && x.PhoneNumber.ToLower() == user.PhoneNumber.ToLower()));
            if (checkUser == null)
            {
                var resultData = await _dALuserManagerService.CreateAsync(user, registerUserViewModel.Password);
                resultModel.IsSuccess = resultData.IsSuccess;
                resultModel.Value = resultData.Value?.Id ?? string.Empty;
            }
           
            resultModel.Message = resultModel.IsSuccess ? "Tạo mới thành công" : "Tạo mới thất bại";
            return resultModel;
        }
    }
}
