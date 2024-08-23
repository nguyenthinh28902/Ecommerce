using Authentication.User.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.DataAccess.Service.UserServices.Interfaces
{
    public interface IDALUserTokenMannagerService
    {
        public Task<bool> CreateAsync(UserToken userToken);
        public Task Demo();
    }
}
