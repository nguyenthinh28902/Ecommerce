using Authentication.User.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.DataAccess.Service.StoreServices.Interfaces
{
    public interface IDALStoreManager
    {
        public Task<bool> IsStoreOwerAsync(string StoreOwer);
        public Task<bool> IsStoreByEmailAsync(string Email);
        public Task<bool> IsStoreByPhoneNumberAsync(string PhoneNumber);
        public Task<Store> CreateAsync(Store store);
        public Task<Store?> GetStoreByIdAsync(Guid Id);
        public Task<bool> UpdateAsync(Store store);
    }
}
