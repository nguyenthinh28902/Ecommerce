﻿using Authentication.User.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.DataAccess.Service.UserServices.Interfaces
{
    public interface IDALUserManagerService
    {
        public Task<ApplicationUser?> GetUserByUserNameAsync(string UserName);
        public Task<ApplicationUser?> GetUserByIdAsync(string Id);
        public Task<ApplicationUser?> FirstOrDefaultAsync(
         Expression<Func<ApplicationUser, bool>> predicate = null);
    }
}
