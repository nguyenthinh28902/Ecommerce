using Authentication.DataAccess.EntityModels;
using Authentication.DataAccess.Service.User.Interface;
using Authentication.Service.ViewModel.SignInViewModels;
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
    public class DALAuthenManagerService : IDALAuthenManagerService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public DALAuthenManagerService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResultModel?> SignInResultAsync(int UserId, string PassWord, bool RememberMe = false)
        {
            var userSignIn = await _userManager.Users.FirstOrDefaultAsync(x => x.UserId == UserId);
            if (userSignIn != null)
            {
                var result = await _signInManager.PasswordSignInAsync(userSignIn, PassWord, RememberMe, true);
                var resultModel = new SignInResultModel();
                resultModel.Succeeded = result.Succeeded;
                resultModel.IsLockedOut = result.IsLockedOut;
                resultModel.RequiresTwoFactor = result.RequiresTwoFactor;
                resultModel.IsEmailConfirmed = _userManager.Options.SignIn.RequireConfirmedAccount;
                return resultModel;
            }
            return null;
        }



        /// <summary>
        /// lấy code xác thực qua email.
        /// </summary>
        /// <param name="user">thông tin user các xác thực</param>
        /// <returns>trả về chuối code xác thực</returns>
        public async Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        /// <summary>
        /// lấy code xác thực qua email.
        /// </summary>
        /// <param name="UserId">userId của user các xác thực</param>
        /// <returns>trả về chuối code xác thực</returns>
        public async Task<string> GenerateEmailConfirmationTokenAsync(int UserId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserId == UserId);
            if (user == null) return string.Empty;
            return await GenerateEmailConfirmationTokenAsync(user);
        }

        /// <summary>
        /// lấy code xác thực qua email.
        /// </summary>
        /// <param name="Id">Id của user các xác thực</param>
        /// <returns>trả về chuối code xác thực</returns>
        public async Task<string> GenerateEmailConfirmationTokenAsync(Guid Id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id.ToLower() == Id.ToString().ToLower());
            if (user == null) return string.Empty;
            return await GenerateEmailConfirmationTokenAsync(user);
        }

    }
}
