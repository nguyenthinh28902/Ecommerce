using Authentication.Service.ViewModel.SignInViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Service.Services.UserService.Interface
{
    public interface IAuthenManagerService
    {
        public Task<SignInResultViewModel> SignInAsync(SignInViewModel signInViewModel);
    }
}
