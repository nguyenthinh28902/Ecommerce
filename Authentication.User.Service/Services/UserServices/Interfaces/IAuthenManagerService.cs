using Authentication.User.Service.ViewModels.SignInViewModels;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.Service.Services.UserServices.Interfaces
{
    public interface IAuthenManagerService
    {
        public Task<SignInResultViewModel> SignInAsync(SignInViewModel signInViewModel, string urlComfirm);
        public Task<SignInResultViewModel> SignInGoogle();
        public Task<ConfirmEmailViewModel> ConfirmEmailAsync(string UserId, string Code);
        public Task<IList<AuthenticationScheme>> GetExternalLoginsAsync();
        public Task<AuthenticationProperties> ExternalLoginAsync(string provider, string returnUrl);
    }
}
