using Authentication.Admin.DataAccess.Entities;
using Authentication.Admin.DataAccess.Service.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Admin.DataAccess.Service.UserServices.Interfaces
{
    public interface IDALUserManagerService
    {
        public Task<ApplicationUser?> GetUserByUserNameAsync(string UserName);
        public Task<ApplicationUser?> GetUserByIdAsync(string Id);
        public Task<DataResultModel<ApplicationUser>> CreateAsync(ApplicationUser user, string PassWord);
        public Task<DataResultModel<ApplicationUser>> UpdateAsync(ApplicationUser user);
        public Task<ApplicationUser?> FirstOrDefaultAsync(
            Expression<Func<ApplicationUser, bool>> predicate = null);
    }
}
