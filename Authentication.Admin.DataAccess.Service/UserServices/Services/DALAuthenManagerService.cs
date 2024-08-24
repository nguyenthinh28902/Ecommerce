using Authentication.Admin.DataAccess.Entities;
using Authentication.Admin.DataAccess.Repositories;
using Authentication.Admin.DataAccess.Service.SignInModels;
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
    public class DALAuthenManagerService : IDALAuthenManagerService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;
        public DALAuthenManagerService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<SignInResultModel?> SignInResultAsync(string UserName, string PassWord, bool RememberMe = false)
        {
            var userSignIn = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == UserName);
            if (userSignIn != null)
            {
                var resultModel = new SignInResultModel();
                try
                {
                    var result = await _signInManager.PasswordSignInAsync(userSignIn, PassWord, RememberMe, true);
                   
                    resultModel.Succeeded = result.Succeeded;
                    resultModel.IsLockedOut = result.IsLockedOut;
                    resultModel.RequiresTwoFactor = result.RequiresTwoFactor;
                    resultModel.IsEmailConfirmed = _userManager.Options.SignIn.RequireConfirmedAccount;
                }
                catch (Exception ex)
                {

                    throw;
                }
                
              
                return resultModel;
            }
            return null;
        }

        /// <summary>
        /// Confirm Email
        /// </summary>
        /// <param name="user">user cần xác nhận</param>
        /// <param name="Code">mã xác nhận</param>
        /// <returns></returns>
        public async Task<bool> ConfirmEmailAsync(ApplicationUser user, string Code)
        {
            var result = await _userManager.ConfirmEmailAsync(user, Code);
            try
            {
                user.UpdateAt = DateTimeOffset.UtcNow;
                var demo = await _userManager.UpdateAsync(user);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return result.Succeeded;
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
        public async Task<string> GenerateEmailConfirmationTokenAsync(string UserName)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == UserName);
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
