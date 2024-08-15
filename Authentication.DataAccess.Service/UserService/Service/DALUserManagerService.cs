using Authentication.DataAccess.EntityModels;
using Authentication.DataAccess.Service.UserService.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.DataAccess.Service.UserService.Service
{
    public class DALUserManagerService : IDALUserManagerService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public DALUserManagerService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser?> GetUserByUserIdAsync(string UserName)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == UserName);
            return user;
        }
    }
}
