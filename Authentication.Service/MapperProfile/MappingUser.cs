using Authentication.DataAccess.EntityModels;
using Authentication.Service.ViewModel.UserViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Service.MapperProfile
{
    public class MappingUser : Profile
    {
        public MappingUser() {
            CreateMap<ApplicationUser, UserViewModel>();
        }
    }
}
