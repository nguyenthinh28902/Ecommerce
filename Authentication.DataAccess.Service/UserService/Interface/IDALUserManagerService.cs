using Authentication.DataAccess.EntityModels.UserEntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.DataAccess.Service.UserService.Interface
{
    public interface IDALUserManagerService
    {
        public Task<ApplicationUser?> GetUserByUserIdAsync(int UserId);
    }
}
