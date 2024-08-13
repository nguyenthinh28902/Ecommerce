using Authentication.DataAccess.EntityModels;
using Authentication.Service.ViewModel.SignInViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.DataAccess.Service.User.Interface
{
    public interface IDALAuthenManagerService
    {
        public Task<SignInResultModel?> SignInResultAsync(int UserId, string PassWord, bool RememberMe);
        public Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        public Task<string> GenerateEmailConfirmationTokenAsync(int UserId);
        public Task<string> GenerateEmailConfirmationTokenAsync(Guid Id);
    }
}
