using Authentication.User.DataAccess.Entities;
using Authentication.User.Service.ViewModels.UserViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.Service.MapperProfiles
{
    public class MappingUser : Profile
    {
        public MappingUser()
        {
            CreateMap<ApplicationUser, UserViewModel>();
            CreateMap<RegisterUserViewModel, ApplicationUser>();
        }
    }
}
