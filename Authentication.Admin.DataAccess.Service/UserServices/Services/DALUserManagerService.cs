using Authentication.Admin.DataAccess.Entities;
using Authentication.Admin.DataAccess.Repositories;
using Authentication.Admin.DataAccess.Service.DataModels;
using Authentication.Admin.DataAccess.Service.UserServices.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Admin.DataAccess.Service.UserServices.Services
{
    public class DALUserManagerService : IDALUserManagerService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        public DALUserManagerService(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApplicationUser?> FirstOrDefaultAsync(
            Expression<Func<ApplicationUser, bool>> predicate = null)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(predicate);
            return user;
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

        public async Task<DataResultModel<ApplicationUser>> CreateAsync(ApplicationUser user, string PassWord)
        {
            var dataResult = new DataResultModel<ApplicationUser>();
            try
            {
                await _userManager.CreateAsync(user, PassWord);
                await _unitOfWork.SaveChangesAsync();
                dataResult.Value = user;
                dataResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                dataResult.IsSuccess = false;
                dataResult.Message = ex.Message;
            }
            return dataResult;
        }


        public async Task<DataResultModel<ApplicationUser>> UpdateAsync(ApplicationUser user)
        {
            var dataResult = new DataResultModel<ApplicationUser>();
            try
            {
                await _userManager.UpdateAsync(user);
                await _unitOfWork.SaveChangesAsync();
                dataResult.Value = user;
                dataResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                dataResult.IsSuccess = false;
                dataResult.Message = ex.Message;
            }
            return dataResult;
        }
    }
}
