using Authentication.DataAccess.EntityModels;
using Authentication.DataAccess.Service.User.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.DataAccess.Service.User.Service
{
    public class UserManagerService : IUserManagerService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserManagerService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Microsoft.AspNetCore.Identity.SignInResult?> SignInResultAsync(int UserId, string PassWord, bool RememberMe = false)
        {
            var userSignIn = await _userManager.Users.FirstOrDefaultAsync(x => x.UserId == UserId);
            if (userSignIn != null)
            {
                var Result = await _signInManager.PasswordSignInAsync(userSignIn, PassWord, RememberMe, true);
                return Result;
            }
            return null;
        }


    }
}
