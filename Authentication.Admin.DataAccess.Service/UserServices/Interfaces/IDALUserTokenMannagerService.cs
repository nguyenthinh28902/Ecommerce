using Authentication.Admin.DataAccess.Entities;
using Authentication.Admin.DataAccess.Service.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Admin.DataAccess.Service.UserServices.Interfaces
{
    public interface IDALUserTokenMannagerService
    {
        public Task<DataResultModel<UserToken>> CreateAsync(UserToken userToken);
    }
}
