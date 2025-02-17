using Authentication.Admin.DataAccess.Entities;
using Authentication.Admin.DataAccess.Service.SignInModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Admin.DataAccess.Service.UserServices.Interfaces
{
    public interface IDALAuthenManagerService
    {
        public Task<SignInResultModel?> SignInResultAsync(string UserName, string PassWord, bool RememberMe);
        public Task<bool> ConfirmEmailAsync(ApplicationUser user, string Code);
        public Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        public Task<string> GenerateEmailConfirmationTokenAsync(string UserName);
        public Task<string> GenerateEmailConfirmationTokenAsync(Guid Id);
    }
}
