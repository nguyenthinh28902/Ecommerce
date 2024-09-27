using Authentication.User.DataAccess.Service.UserServices.Interfaces;
using Authentication.User.Service.Services.UserServices.Interfaces;
using Authentication.User.Service.ViewModels.UserViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.Service.Services.UserServices.Services
{
    public class UserInformationService : IUserInformationService
    {
        private readonly IDALUserManagerService _dALUserManagerService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;

        public UserInformationService(IDALUserManagerService DALUserManagerService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _dALUserManagerService = DALUserManagerService;
            _mapper = mapper;
            _accessor = httpContextAccessor;
        }

        public string? GetUserId()
        {
            var claimsPrincipal = _accessor.HttpContext?.User;
            if (claimsPrincipal != null)
            {
                var usernameClaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);
                return usernameClaim?.Value;
            }
            return null;
        }
       
    }
}
