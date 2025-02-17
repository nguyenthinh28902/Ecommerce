using Authentication.Admin.Service.ViewModels.DefaultModels;
using Authentication.Admin.Service.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Admin.Service.Services.UserServices.Interfaces
{
    public interface IUserManagerService
    {
        public Task<ResultModel<string>> CreatedUserAsync(RegisterUserViewModel registerUserViewModel);
    }
}
