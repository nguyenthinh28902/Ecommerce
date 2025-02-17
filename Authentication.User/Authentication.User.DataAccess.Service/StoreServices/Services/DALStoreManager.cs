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
        private readonly IRepository<Store> _storeRepository;
        private readonly ILogger<DALStoreManager> _logger;
        public DALStoreManager(IUnitOfWork unitOfWork, ILogger<DALStoreManager> logger)
        {
            _unitOfWork = unitOfWork;
            _storeRepository = unitOfWork.GetRepository<Store>();
            _logger = logger;
        }

        public async Task<bool> IsStoreOwerAsync(string StoreOwer)
        {
            var IsStoreOwer = await _storeRepository.AnyAsync(x => x.StoreOwer.ToLower() == StoreOwer.ToLower());
            return IsStoreOwer;
        }

        public async Task<bool> IsStoreByEmailAsync(string Email)
        {
            var IsStoreOwer = await _storeRepository.AnyAsync(x => x.Email.ToLower() == Email.ToLower());
            return IsStoreOwer;
        }
        public async Task<bool> IsStoreByPhoneNumberAsync(string PhoneNumber)
        {
            var IsStoreOwer = await _storeRepository.AnyAsync(x => x.PhoneNumber.ToLower() == PhoneNumber.ToLower());
            return IsStoreOwer;
        }

        public async Task<Store> CreateAsync(Store store)
        {
            try
            {
                await _storeRepository.AddAsync(store);
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

        public async Task<Store?> GetStoreByIdAsync(Guid Id)
        {
            var store =  await _storeRepository.GetByIdAsync(Id);
            return store;
        }

        public async Task<bool> UpdateAsync(Store store)
        {
            try
            {
                _storeRepository.Update(store);
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
