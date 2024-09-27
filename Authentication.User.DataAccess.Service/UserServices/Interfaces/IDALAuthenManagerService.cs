using Authentication.User.DataAccess.Entities;
using Authentication.User.DataAccess.Service.DataModels;
using Authentication.User.DataAccess.Service.SignInModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.DataAccess.Service.UserServices.Interfaces
{
    public interface IDALAuthenManagerService
    {
        public Task<SignInResultModel?> SignInResultAsync(string UserName, string PassWord, bool RememberMe);
        public Task<ApplicationUser?> SignInResultAsync(string UserName);
        public Task<bool> ConfirmEmailAsync(ApplicationUser user, string Code);
        public Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        public Task<string> GenerateEmailConfirmationTokenAsync(string UserName);
        public Task<string> GenerateEmailConfirmationTokenAsync(Guid Id);
        public Task<DataResultModel<ApplicationUser>> CreateAsync(ApplicationUser user, string PassWord);
        public Task<IList<AuthenticationScheme>> ExternalLogins();
        public Task<AuthenticationProperties> ExternalLoginAsync(string provider, string returnUrl);
        public Task<ExternalLoginInfo?> GetExternalLoginInfoAsync();
    }
}
