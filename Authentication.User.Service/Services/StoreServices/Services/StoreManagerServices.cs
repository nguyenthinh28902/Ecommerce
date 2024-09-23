using Authentication.User.DataAccess.Service.StoreServices.Interfaces;
using Authentication.User.Service.Services.StoreServices.Interfaces;
using Authentication.User.Service.ViewModels;
using Authentication.User.Service.ViewModels.StoreViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.Service.Services.StoreServices.Services
{
    public class StoreManagerServices : IStoreManagerServices
    {
        private readonly IMapper _mapper;
        public readonly IDALStoreManager _dALStoreManager;
        public StoreManagerServices(IMapper Mapper, IDALStoreManager DALStoreManager)
        {
            _mapper = Mapper;
            _dALStoreManager = DALStoreManager;
        }

        //public async Task<ResultModel<Guid>> Register(RegisterStoreViewModel registerStoreViewModel)
        //{

        //}
    }
}
