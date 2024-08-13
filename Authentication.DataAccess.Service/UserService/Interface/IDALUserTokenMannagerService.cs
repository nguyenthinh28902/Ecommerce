using Authentication.DataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.DataAccess.Service.UserService.Interface
{
    public interface IDALUserTokenMannagerService
    {
        public Task<bool> CreateAsync(UserToken userToken);
    }
}
