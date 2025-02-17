using Authentication.User.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.Service.Services.StoreServices.Interfaces.AdminService
{
    public interface IStoreManagerAdminServices
    {
        public Task<ResultModel<Guid>> StoreApproveAsync(Guid storeId);
    }
}
