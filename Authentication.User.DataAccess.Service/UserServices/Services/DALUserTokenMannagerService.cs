﻿using Authentication.User.DataAccess.Entities;
using Authentication.User.DataAccess.Repositories;
using Authentication.User.DataAccess.Service.UserServices.Interfaces;
using FeatureLibrary.LogLibrary;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.DataAccess.Service.UserServices.Services
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

        public async Task<bool> CreateAsync(UserToken userToken)
        {
            try
            {
                await _userRepository.AddAsync(userToken);
                await _unitOfWork.CommitAsync();
                await _unitOfWork.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                var informationLoger = new InformationLoger(nameof(CreateAsync), ex, userToken);
                _logger.LogError(informationLoger.GetMessage());
                return false;
            }
            return true;
        }
        public async Task Demo()
        {
            await _unitOfWork.CommitAsync();
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
