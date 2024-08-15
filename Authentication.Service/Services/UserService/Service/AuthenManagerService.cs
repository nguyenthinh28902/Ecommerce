using Authentication.DataAccess.EntityModels;
using Authentication.DataAccess.Service.User.Interface;
using Authentication.DataAccess.Service.User.Service;
using Authentication.DataAccess.Service.UserService.Interface;
using Authentication.Service.Constructors;
using Authentication.Service.Helpers.Jwt;
using Authentication.Service.Services.EmailService;
using Authentication.Service.Services.UserService.Interface;
using Authentication.Service.ViewModel.Enum;
using Authentication.Service.ViewModel.Settings;
using Authentication.Service.ViewModel.SignInViewModels;
using Authentication.Service.ViewModel.UserViewModels;
using AutoMapper;
using FeatureLibrary.EmailLibrary;
using FeatureLibrary.IOLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.DataAccess.Enums;
using Microsoft.AspNetCore.WebUtilities;
namespace Authentication.Service.Services.UserService.Service
{
    public class AuthenManagerService : IAuthenManagerService
    {
        private readonly IDALAuthenManagerService _dALAuthenManagerService;
        private readonly IDALUserManagerService _dALUserManagerService;
        private readonly IEmailSender _sendMailService;
        private readonly IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;
        private readonly IDALUserTokenMannagerService _dALUserTokenMannagerService;
        private readonly IHttpContextAccessor _accessor;
        public AuthenManagerService(IDALAuthenManagerService dALAuthenManagerService, IDALUserManagerService dALUserManagerService,
           IEmailSender sendMailService, IJwtUtils jwtUtils, IMapper mapper,
           IDALUserTokenMannagerService dALUserTokenMannagerService,
           IHttpContextAccessor accessor)
        {
            _dALAuthenManagerService = dALAuthenManagerService;
            _dALUserManagerService = dALUserManagerService;
            _sendMailService = sendMailService;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
            _dALUserTokenMannagerService = dALUserTokenMannagerService;
            _accessor = accessor;
        }

        public async Task<SignInResultViewModel> SignInAsync(SignInViewModel signInViewModel)
        {
            var signInResult = await CheckSignInAsync(signInViewModel);
            if (signInResult.IsSucceeded)
            {
                var user = await _dALUserManagerService.GetUserByUserIdAsync(signInViewModel.UserName);
                var userViewModel = _mapper.Map<UserViewModel>(user);
                try
                {
                    var jwtToken = _jwtUtils.GenerateToken(userViewModel);
                    signInResult.Token = jwtToken.Token;
                   var IpAddress = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                    var userToken = DataModel.CreateUserToken(jwtToken.Token, EnumLoginProvider.Default.ToString(), signInViewModel.AppName,
                        jwtToken.ExpiresAt, user?.Id??string.Empty, TokenType.login, IpAddress ?? string.Empty);
                    await _dALUserTokenMannagerService.CreateAsync(userToken);
                }
                catch (Exception)
                {
                    signInResult.IsSucceeded = false;
                    signInResult.Message = "Có lỗi trong quá trính xử lý";
                }
            }
            return signInResult;
        }

        public async Task<SignInResultViewModel> CheckSignInAsync(SignInViewModel signInViewModel)
        {
            var signInResultViewModel = new SignInResultViewModel();
            var signInResult = await _dALAuthenManagerService.SignInResultAsync(signInViewModel.UserName, signInViewModel.PassWord, signInViewModel.RememberMe);
            signInResultViewModel.IsSucceeded = signInResult == null ? false : signInResult.Succeeded;
            if (signInResult != null && !signInResult.Succeeded)
            {
                var user = await _dALUserManagerService.GetUserByUserIdAsync(signInViewModel.UserName);
                if (user != null && (user.EmailConfirmed || user.PhoneNumberConfirmed))
                {
                    var IsAuthenSendMail = await AuthenSendMail(user);
                    signInResultViewModel.Message = IsAuthenSendMail ? "Kiểm tra email" : "Có lỗi trong quá trính xử lý";
                }
                return signInResultViewModel;
            }
            if (!signInResultViewModel.IsSucceeded)
            {
                signInResultViewModel.Message = "Thông tin đăng nhập sai";
            }
            signInResultViewModel.Message = "Đăng nhập thành công";
            return signInResultViewModel;
        }

        public async Task<bool> AuthenSendMail(ApplicationUser applicationUser)
        {
            var emailConfirmation = await _dALAuthenManagerService.GenerateEmailConfirmationTokenAsync(applicationUser);
            emailConfirmation = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(emailConfirmation));
            if (string.IsNullOrEmpty(emailConfirmation) || string.IsNullOrEmpty(applicationUser.Email)) { return false; }
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var templatePath = Path.Combine(baseDirectory, "Templates\\AuthenticationMail.html");
            var template = IOLibrary.LoadTemplate(templatePath);
            template = template.Replace(EmailBody.AuthenticationMailCode, emailConfirmation);
            var Subject = "[E-commerce Management] Thông báo code xác thực";
            try
            {
                await _sendMailService.SendEmailAsync(applicationUser.Email, Subject, template);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
