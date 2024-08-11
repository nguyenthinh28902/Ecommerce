using Authentication.DataAccess.EntityModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.DataAccess.Service.User.Interface
{
    public interface IUserManagerService
    {
        public Task<SignInResult?> SignInResultAsync(int UserId, string PassWord, bool RememberMe);
    }
}
