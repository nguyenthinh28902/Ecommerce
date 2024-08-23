using Authentication.Admin.DataAccess.Entities;
using Authentication.Admin.DataAccess.Service.UserServices.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Admin.DataAccess.Service.UserServices.Services
{
    public class DALUserManagerService : IDALUserManagerService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public DALUserManagerService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser?> GetUserByUserNameAsync(string UserName)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == UserName);
            return user;
        }
        public async Task<ApplicationUser?> GetUserByIdAsync(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            return user;
        }
    }
}
