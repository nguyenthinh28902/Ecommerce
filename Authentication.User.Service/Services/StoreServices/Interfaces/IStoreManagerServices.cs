using Authentication.User.Service.ViewModels;
using Authentication.User.Service.ViewModels.StoreViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.Service.Services.StoreServices.Interfaces
{
    public interface IStoreManagerServices
    {
        public Task<ResultModel<Guid>> Register(RegisterStoreViewModel registerStoreViewModel);
    }
}
