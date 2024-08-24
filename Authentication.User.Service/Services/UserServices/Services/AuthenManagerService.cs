﻿using Authentication.User.DataAccess.Entities;
using Authentication.User.DataAccess.Enums;
using Authentication.User.DataAccess.Service.UserServices.Interfaces;
using Authentication.User.Service.Constructors;
using Authentication.User.Service.Helpers.Jwts;
using Authentication.User.Service.Services.EmailService;
using Authentication.User.Service.Services.UserServices.Interfaces;
using Authentication.User.Service.ViewModels.Enum;
using Authentication.User.Service.ViewModels.SignInViewModels;
using Authentication.User.Service.ViewModels.UserViewModels;
using AutoMapper;
using FeatureLibrary.IOLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public AuthenManagerService(IDALAuthenManagerService dALAuthenManagerService, IDALUserManagerService dALUserManagerService,
           IEmailService sendMailService, IJwtUtils jwtUtils, IMapper mapper,
           IHttpContextAccessor accessor,
           IDALUserTokenMannagerService dALUserTokenMannagerService)
        {
            _dALAuthenManagerService = dALAuthenManagerService;
            _dALUserManagerService = dALUserManagerService;
            _sendMailService = sendMailService;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
            _accessor = accessor;
            _dALUserTokenMannagerService = dALUserTokenMannagerService;
        }

        public async Task<SignInResultViewModel> SignInAsync(SignInViewModel signInViewModel, string urlComfirm)
        {
            var signInResult = await CheckSignInAsync(signInViewModel);
            var user = await _dALUserManagerService.GetUserByUserNameAsync(signInViewModel.UserName);
            if (signInResult.IsSucceeded)
            {
                var userViewModel = _mapper.Map<UserViewModel>(user);
                try
                {
                    var jwtToken = _jwtUtils.GenerateToken(userViewModel);
                    signInResult.Token = jwtToken.Token;
                    var IpAddress = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                    var userToken = DataModel.CreateUserToken(jwtToken.Token, EnumLoginProvider.Default.ToString(), signInViewModel.AppName,
                        jwtToken.ExpiresAt, user?.Id ?? string.Empty, TokenType.login, IpAddress ?? string.Empty);
                    await _dALUserTokenMannagerService.CreateAsync(userToken);
                }
                catch (Exception)
                {
                    signInResult.IsSucceeded = false;
                    signInResult.Message = "Có lỗi trong quá trính xử lý";
                }
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

    }
}