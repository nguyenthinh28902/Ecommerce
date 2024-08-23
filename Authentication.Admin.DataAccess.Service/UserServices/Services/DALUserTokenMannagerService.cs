using Authentication.Admin.DataAccess.Entities;
using Authentication.Admin.DataAccess.Repositories;
using Authentication.Admin.DataAccess.Service.DataModels;
using Authentication.Admin.DataAccess.Service.UserServices.Interfaces;
using FeatureLibrary.LogLibrary;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Admin.DataAccess.Service.UserServices.Services
{
    public class DALUserTokenMannagerService : IDALUserTokenMannagerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserToken> _userRepository;
        private readonly ILogger<DALUserTokenMannagerService> _logger;
        public DALUserTokenMannagerService(IUnitOfWork unitOfWork, ILogger<DALUserTokenMannagerService> logger)
        {
            _unitOfWork = unitOfWork;
            _userRepository = unitOfWork.GetRepository<UserToken>();
            _logger = logger;
        }

        public async Task<DataResultModel<UserToken>> CreateAsync(UserToken userToken)
        {
            var result = new DataResultModel<UserToken>();
            try
            {
               
                await _userRepository.AddAsync(userToken);
                await _unitOfWork.CommitAsync();
                await _unitOfWork.SaveChangeAsync();
                result.Value = userToken;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                var informationLoger = new InformationLoger(nameof(CreateAsync), ex, userToken);
                _logger.LogError(informationLoger.GetMessage());
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
