using Authentication.Admin.DataAccess.Entities;
using Authentication.Admin.Service.ViewModels.UserViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Admin.Service.MapperProfiles
{
    public class MappingUser : Profile
    {
        public MappingUser()
        {
            CreateMap<ApplicationUser, UserViewModel>();
        }
    }
}
