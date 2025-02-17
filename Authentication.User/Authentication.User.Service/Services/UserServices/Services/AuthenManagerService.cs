using Authentication.User.DataAccess.Entities;
using Authentication.User.DataAccess.Enums;
using Authentication.User.DataAccess.Service.UserServices.Interfaces;
using Authentication.User.Service.Constructors;
using Authentication.User.Service.Helpers.Jwts;
using Authentication.User.Service.Services.EmailService;
using Authentication.User.Service.Services.GoogleServices.DataModels;
using Authentication.User.Service.Services.GoogleServices.Interfaces;
using Authentication.User.Service.Services.UserServices.Interfaces;
using Authentication.User.Service.ViewModels;
using Authentication.User.Service.ViewModels.Enum;
using Authentication.User.Service.ViewModels.SignInViewModels;
using Authentication.User.Service.ViewModels.UserViewModels;
using AutoMapper;
using FeatureLibrary.IOLibrary;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.Service.Services.UserServices.Services
{
    public class AuthenManagerService : IAuthenManagerService
    {
        private readonly IDALAuthenManagerService _dALAuthenManagerService;
        private readonly IDALUserManagerService _dALUserManagerService;
        private readonly IEmailService _sendMailService;
        private readonly IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;
        private readonly IDALUserTokenMannagerService _dALUserTokenMannagerService;
        private readonly IGoogleTokenService _googleTokenService;
        public AuthenManagerService(IDALAuthenManagerService dALAuthenManagerService, IDALUserManagerService dALUserManagerService,
           IEmailService sendMailService, IJwtUtils jwtUtils, IMapper mapper,
           IHttpContextAccessor accessor,
           IDALUserTokenMannagerService dALUserTokenMannagerService,
           IGoogleTokenService googleTokenService)
        {
            _dALAuthenManagerService = dALAuthenManagerService;
            _dALUserManagerService = dALUserManagerService;
            _sendMailService = sendMailService;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
            _accessor = accessor;
            _dALUserTokenMannagerService = dALUserTokenMannagerService;
            _googleTokenService = googleTokenService;
        }

        public async Task<SignInResultViewModel> SignInAsync(SignInViewModel signInViewModel, string urlComfirm)
        {
            var signInResult = await CheckSignInAsync(signInViewModel);
            var user = await _dALUserManagerService.GetUserByUserNameAsync(signInViewModel.UserName);
            if (signInResult.IsSucceeded && user != null)
            {
                signInResult = await GenerateToken(user, signInViewModel.AppName.ToString());
            }
            else if (user != null)
            {
                if ((!user.EmailConfirmed && !user.PhoneNumberConfirmed))
                {
                    var IsAuthenSendMail = await AuthenSendMail(user, urlComfirm);
                    signInResult.Message = IsAuthenSendMail ? "Kiểm tra email" : "Có lỗi trong quá trính xử lý";
                }
            }
            return signInResult;
        }

        public async Task<SignInResultViewModel> SignInGoogle()
        {
            var signInResult = new SignInResultViewModel();

            var userInfo = await _dALAuthenManagerService.GetExternalLoginInfoAsync();
            if (userInfo == null)
            {
                signInResult.Message = Message.MessageSiginFailure;
                return signInResult;
            }
            var email = userInfo.Principal.FindFirstValue(ClaimTypes.Email) ?? string.Empty;
            var avatarUrl = userInfo.Principal.FindFirstValue("image");
            var IsComfirm = false;
            var user = await _dALUserManagerService.GetUserByUserNameAsync(email);
            if (user == null)
            {
                var registerUser = new RegisterUserViewModel(email, email, email, string.Empty, avatarUrl);
                var registerResult = await RegisterUserAsync(registerUser, IsComfirm);
                if (registerResult.IsSuccess == false)
                {
                    signInResult.Message = Message.MessageInforFailure;
                    return signInResult;
                }
            }
                signInResult = await SignInAsync(email, IsComfirm);
            return signInResult;
        }

        public async Task<SignInResultViewModel> SignInAsync(string Email, bool IsComfirm = false)
        {
            var signInResult = new SignInResultViewModel();
            var user = await _dALUserManagerService.GetUserByUserNameAsync(Email);
            if (user == null)
            {
                var registerUser = new RegisterUserViewModel(Email, Email, Email, string.Empty);
                var registerResult = await RegisterUserAsync(registerUser, IsComfirm);
                if (registerResult.IsSuccess == false)
                {
                    signInResult.Message = Message.MessageInforFailure;
                    return signInResult;
                }
            }
            user = await _dALAuthenManagerService.SignInResultAsync(Email);
            if (user == null) { throw new Exception(); }
            signInResult = await GenerateToken(user, EnumLoginAppName.Google.ToString());
            return signInResult;
        }

        public async Task<SignInResultViewModel> GenerateToken(ApplicationUser user, string AppName) {
            var signInResult = new SignInResultViewModel();
            var userViewModel = _mapper.Map<UserViewModel>(user);
            try
            {
                var jwtToken = _jwtUtils.GenerateToken(userViewModel);
                signInResult.Token = jwtToken.Token;
                var IpAddress = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                var userToken = DataModel.CreateUserToken(jwtToken.Token, EnumLoginProvider.Default.ToString(), AppName,
                    jwtToken.ExpiresAt, user?.Id ?? string.Empty, TokenType.login, IpAddress ?? string.Empty);
                signInResult.IsSucceeded = true;
                await _dALUserTokenMannagerService.CreateAsync(userToken);
            }
            catch (Exception)
            {
                signInResult.IsSucceeded = false;
                signInResult.Message = "Có lỗi trong quá trính xử lý";
            }
            return signInResult;
        }

        public async Task<SignInResultViewModel> CheckSignInAsync(SignInViewModel signInViewModel)
        {
            var signInResultViewModel = new SignInResultViewModel();
            var signInResult = await _dALAuthenManagerService.SignInResultAsync(signInViewModel.UserName, signInViewModel.PassWord, signInViewModel.RememberMe);
            signInResultViewModel.IsSucceeded = signInResult == null ? false : signInResult.Succeeded;
            if (!signInResultViewModel.IsSucceeded)
            {
                signInResultViewModel.Message = "Thông tin đăng nhập sai";
                return signInResultViewModel;
            }
            signInResultViewModel.Message = "Đăng nhập thành công";
            return signInResultViewModel;
        }

        public async Task<bool> AuthenSendMail(ApplicationUser applicationUser, string urlComfirm)
        {
            var emailConfirmation = await _dALAuthenManagerService.GenerateEmailConfirmationTokenAsync(applicationUser);
            emailConfirmation = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(emailConfirmation));
            if (string.IsNullOrEmpty(emailConfirmation) || string.IsNullOrEmpty(applicationUser.Email)) { return false; }
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var templatePath = Path.Combine(baseDirectory, "Templates\\AuthenticationMail.html");
            var template = IOLibrary.LoadTemplate(templatePath);
            template = template.Replace(EmailBody.AuthenticationMailCode, emailConfirmation);
            template = template.Replace(EmailBody.AuthenticationMailUrl, urlComfirm);
            template = template.Replace(EmailBody.AuthenticationMailUserId, applicationUser.Id);
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

        public async Task<ConfirmEmailViewModel> ConfirmEmailAsync(string UserId, string Code)
        {
            var confirmEmailViewModel = new ConfirmEmailViewModel();
            var user = await _dALUserManagerService.GetUserByIdAsync(UserId);
            if (user == null) { confirmEmailViewModel.Message = "Người dùng không tồn tại."; return confirmEmailViewModel; }
            Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(Code));
            var IsConfirmEmail = await _dALAuthenManagerService.ConfirmEmailAsync(user, Code);
            await _dALUserTokenMannagerService.Demo();
            confirmEmailViewModel.IsSucceeded = IsConfirmEmail;
            confirmEmailViewModel.Message = IsConfirmEmail ? "Xác nhận mã thành công." : "Xác nhận mã thất bại.";
            return confirmEmailViewModel;
        }
        public async Task<ResultModel<string>> RegisterUserAsync(RegisterUserViewModel registerUserViewModel, bool IsComfirm = false)
        {
            var user = _mapper.Map<ApplicationUser>(registerUserViewModel);
            if (IsComfirm)
            {
                user.EmailConfirmed = true;
            }
            var resultModel = new ResultModel<string>();
            var checkUser = await _dALUserManagerService.FirstOrDefaultAsync(x => x.Id == user.Id
                || x.UserName == user.UserName
                || (x.Email != null && x.Email.ToLower() == user.Email.ToLower())
                || (x.PhoneNumber != null && x.PhoneNumber.ToLower() == user.PhoneNumber.ToLower()));
            if (checkUser == null)
            {
                var resultData = await _dALAuthenManagerService.CreateAsync(user, registerUserViewModel.Password);
                resultModel.IsSuccess = resultData.IsSuccess;
                resultModel.Value = resultData.Value?.Id ?? string.Empty;
            }

            resultModel.Message = resultModel.IsSuccess ? "Tạo mới thành công" : "Tạo mới thất bại";
            return resultModel;
        }
        public async Task<IList<AuthenticationScheme>> GetExternalLoginsAsync()
        {
            return await _dALAuthenManagerService.ExternalLogins();
        }
        public async Task<AuthenticationProperties> ExternalLoginAsync(string provider, string returnUrl)
        {
            return await _dALAuthenManagerService.ExternalLoginAsync(provider, returnUrl);
        }

        
    }
}
