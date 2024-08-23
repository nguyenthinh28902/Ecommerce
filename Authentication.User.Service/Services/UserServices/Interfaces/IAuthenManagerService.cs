using Authentication.User.Service.ViewModels.SignInViewModels;
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
        public Task<ConfirmEmailViewModel> ConfirmEmailAsync(string UserId, string Code);
    }
}
