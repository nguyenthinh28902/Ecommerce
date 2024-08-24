using Authentication.Admin.DataAccess.Entities;
using Authentication.Admin.Service.ViewModels.SignInViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Admin.Service.Services.UserServices.Interfaces
{
    public interface IAuthenManagerService
    {
        public Task<SignInResultViewModel> SignInAsync(SignInViewModel signInViewModel, string urlComfirm);
        public Task<SignInResultViewModel> CheckSignInAsync(SignInViewModel signInViewModel);
        public Task<ConfirmEmailViewModel> ConfirmEmailAsync(string UserId, string Code);
        public Task<bool> AuthenSendMailAsync(string UserId, string urlComfirm);
        public Task<string> GenerateEmailConfirmationTokenAsync(string UserId);
    }
}
