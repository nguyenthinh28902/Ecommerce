using Authentication.User.DataAccess.Entities;
using Authentication.User.DataAccess.Repositories;
using Authentication.User.DataAccess.Service.StoreServices.Interfaces;
using FeatureLibrary.LogLibrary;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.DataAccess.Service.StoreServices.Services
{
    public class DALStoreManager : IDALStoreManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Store> _userRepository;
        private readonly ILogger<DALStoreManager> _logger;
        public DALStoreManager(IUnitOfWork unitOfWork, ILogger<DALStoreManager> logger)
        {
            _unitOfWork = unitOfWork;
            _userRepository = unitOfWork.GetRepository<Store>();
            _logger = logger;
        }
        public async Task<Store> CreateAsync(Store store)
        {
            try
            {
                await _userRepository.AddAsync(store);
                await _unitOfWork.CommitAsync();
                await _unitOfWork.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                var informationLoger = new InformationLoger(nameof(CreateAsync), ex, store);
                _logger.LogError(informationLoger.GetMessage());
            }
           
             return store;
            
        }

        public async Task<bool> UpdateAsync(Store store)
        {
            try
            {
                _userRepository.Update(store);
                await _unitOfWork.CommitAsync();
                await _unitOfWork.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                var informationLoger = new InformationLoger(nameof(UpdateAsync), ex, store);
                _logger.LogError(informationLoger.GetMessage());
                return false;
            }
            return true;

        }
    }
}
