﻿using Authentication.User.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.DataAccess.Service.StoreServices.Interfaces
{
    public interface IDALStoreManager
    {
        public Task<Store> CreateAsync(Store store);
        public Task<bool> UpdateAsync(Store store);
    }
}
