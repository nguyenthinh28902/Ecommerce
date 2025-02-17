using Authentication.User.DataAccess.Entities;
using Authentication.User.Service.ViewModels.StoreViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.Service.MapperProfiles
{
    public class MappingStore : Profile
    {
        public MappingStore() {

            CreateMap<Store, RegisterStoreViewModel>();
            CreateMap<RegisterStoreViewModel, Store>();

        }
    }
}
